using Fannan.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fannan.Web.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel login)
        {
            if (!ModelState.IsValid)
            {

            }

            return View();
        }


        public IActionResult Signup()
        {
            return View();
        }
    }
}
