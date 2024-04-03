using Fannan.Web.Data;
using Fannan.Web.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Fannan.Web.Controllers
{
    public class DiscoverController(ApplicationDbContext dbContext) : Controller
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public async Task<IActionResult> Index([FromQuery] string? search)
        {
            var currentUser = await _dbContext.Users
                    .Where(u => u.Id == int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value))
                    .FirstAsync();

            ViewBag.Username = currentUser.Username;
            ViewBag.ProfilePicture = currentUser.ProfilePictureId;
            ViewBag.CurrentUrl = "/Discover";
            ViewBag.Search = search;

            if (search != null)
            {
                var users = await _dbContext.Users
                    .Where(u => u.Username.StartsWith(search))
                    .OrderBy(u => u.Username)
                    .ToListAsync();
                return View(users);
            }

            return View(new List<User>());
        }
    }
}
