using Fannan.Web.Data;
using Fannan.Web.Entities;
using Fannan.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Fannan.Web.Controllers
{
    public class AuthController(ApplicationDbContext dbContext) : Controller
    {
        public IActionResult Login([FromQuery] string returnUrl = "/feed")
        {
            if (User.Identity?.IsAuthenticated != null && User.Identity.IsAuthenticated)
            {
                return LocalRedirect(returnUrl);
            }

            return View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel login)
        {
            if (User.Identity?.IsAuthenticated != null && User.Identity.IsAuthenticated)
            {
                return LocalRedirect(login.ReturnUrl);
            }

            if (ModelState.IsValid)
            {
                var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == login.Email && u.Password == login.Password);
                if (user == null)
                {
                    ViewBag.Message = "Invalid credential";
                    return View(login);
                }
                else
                {
                    var claims = new List<Claim>
                    {
                        new(ClaimTypes.NameIdentifier, user.Id.ToString())
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
                    {
                        IsPersistent = login.RememberMe
                    });
                    return LocalRedirect(login.ReturnUrl);
                }
            }
            return View(login);
        }


        public IActionResult Signup()
        {
            if (User.Identity?.IsAuthenticated != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(Login));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(SignupModel signup)
        {
            if (User.Identity?.IsAuthenticated != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(Login));
            }

            if (ModelState.IsValid)
            {
                if (await dbContext.Users.AnyAsync(u => u.Email == signup.Email || u.Username == signup.Username))
                {
                    ViewBag.Message = "User already exists";
                    return View(signup);
                }
                else
                {
                    await dbContext.Users.AddAsync(new User
                    {
                        FirstName = signup.FirstName,
                        LastName = signup.LastName,
                        Username = signup.Username,
                        Password = signup.Password,
                        Email = signup.Email,
                        Joined = DateTime.UtcNow
                    });

                    await dbContext.SaveChangesAsync();

                    return RedirectToAction(nameof(Login));
                }
            }
            return View(signup);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
