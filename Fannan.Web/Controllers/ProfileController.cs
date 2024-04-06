using Fannan.Web.Data;
using Fannan.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Fannan.Web.Controllers
{
    public class ProfileController(ApplicationDbContext dbContext) : Controller
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        [HttpGet("Profile/{username}")]
        public async Task<IActionResult> Index([FromRoute] string? username)
        {
            var currentUser = await _dbContext.Users
                    .Where(u => u.Id == int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value))
                    .FirstAsync();

            ViewBag.Username = currentUser.Username;
            ViewBag.ProfilePicture = currentUser.ProfilePictureId;
            ViewBag.CurrentUrl = "/Profile";
            ViewBag.CanFollow = true;

            if (username == null)
            {
                return RedirectToAction(nameof(Index), new { username = currentUser.Username });
            }

            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (user == null)
            {
                return LocalRedirect("/feed");
            }

            var followers = await _dbContext.Follows
                .Where(f => f.FollowedId == currentUser.Id)
                .ToListAsync();

            return View(new ProfileModel
            {
                CanFollow = !followers.Any(f => f.FollowingUserId == user.Id),
                User = user,
                Posts = await _dbContext.Posts
                .Where(p => p.UserId == user.Id)
                .Include(u => u.Likes)
                .Include(u => u.Comments)
                .ToListAsync()
            });
        }

        [HttpPost("Profile")]
        public async Task<IActionResult> Index([FromForm] ProfileEdit profile)
        {
            var currentUser = await _dbContext.Users
                    .Where(u => u.Id == int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value))
                    .FirstAsync();

            currentUser.FirstName = profile.FirstName ?? "";
            currentUser.LastName = profile.LastName ?? "";
            currentUser.PhoneNumber = profile.Phone ?? "";
            currentUser.Bio = profile.Bio ?? "";
            currentUser.Gender = profile.Gender ?? "";
            currentUser.DateOfBirth = profile.DateOfBirth;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index), new { username = currentUser.Username });
        }
    }
}
