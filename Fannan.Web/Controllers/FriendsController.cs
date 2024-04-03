using Fannan.Web.Data;
using Fannan.Web.Entities;
using Fannan.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Fannan.Web.Controllers
{
    public class FriendsController(ApplicationDbContext dbContext) : Controller
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        [HttpGet("Friends/{username?}")]
        public async Task<IActionResult> Index([FromRoute] string? username)
        {
            var currentUser = await _dbContext.Users
                    .Where(u => u.Id == int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value))
                    .FirstAsync();

            ViewBag.Username = currentUser.Username;
            ViewBag.UserId = currentUser.Id;
            ViewBag.ProfilePicture = currentUser.ProfilePictureId;
            ViewBag.CurrentUrl = "/Friends";

            var friends = await _dbContext.Follows
                .Where(f => f.FollowedId == currentUser.Id)
                .Select(f => f.FollowingUser!)
                .ToListAsync();

            if (!string.IsNullOrEmpty(username))
            {
                var friend = friends.FirstOrDefault(f => f.Username == username);

                if (friend != null)
                {
                    ViewBag.Friend = username;

                    var messages = await _dbContext.Messages
                    .Where(m =>
                    (m.SenderId == currentUser.Id && m.ReceiverId == friend.Id)
                    || (m.SenderId == friend.Id && m.ReceiverId == currentUser.Id))
                    .OrderBy(m => m.Date)
                    .ToListAsync();

                    return View(new FriendMessagingModel
                    {
                        Friends = friends,
                        Messages = messages
                    });
                }
            }

            return View(new FriendMessagingModel
            {
                Friends = friends,
                Messages = []
            });
        }

        [HttpPost("Friends/{username}")]
        public async Task<IActionResult> SendMessage([FromRoute] string username, [FromForm] string message)
        {
            var currentUser = await _dbContext.Users
                    .Where(u => u.Id == int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value))
                    .FirstAsync();

            var friends = await _dbContext.Follows
                .Where(f => f.FollowedId == currentUser.Id)
                .Select(f => f.FollowingUser!)
                .ToListAsync();

            var receiver = friends.FirstOrDefault(u => u.Username == username);

            if (receiver != null)
            {
                await _dbContext.Messages.AddAsync(new Message
                {
                    SenderId = currentUser.Id,
                    ReceiverId = receiver.Id,
                    Content = message,
                    Date = DateTime.UtcNow
                });

                await _dbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index), new { username });
            }

            return RedirectToAction(nameof(Index));
        }
    }
}