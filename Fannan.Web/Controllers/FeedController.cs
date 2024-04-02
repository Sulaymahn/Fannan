﻿using Fannan.Web.Data;
using Fannan.Web.Entities;
using Fannan.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Fannan.Web.Controllers
{
    [Authorize]
    public class FeedController(ApplicationDbContext dbContext) : Controller
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public async Task<IActionResult> Index()
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value));
            if (user == null)
            {
                await HttpContext.SignOutAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Username = user.Username;
            ViewBag.CurrentUrl = Request.Path;
            ViewBag.ProfilePicture = user.ProfilePictureId;

            var followers = await _dbContext.Follows
                .AsNoTracking()
                .Where(f => f.UserId == user.Id)
                .Select(f => f.FollowingUserId)
                .ToListAsync();

            var posts = await _dbContext.Posts
                .AsNoTracking()
                .Where(p => followers.Contains(p.UserId))
                .Include(p => p.Likes)
                .Include(p => p.Media)
                .Include(p => p.User)
                .Include(p => p.Comments)
                .ThenInclude(c => c.Replies)
                .Include(p => p.Comments)
                .ThenInclude(c => c.User)
                .OrderByDescending(p => p.Date)
                .ToListAsync();

            return View(posts);
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm] PostModel post)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value));
            if (user == null)
            {
                await HttpContext.SignOutAsync();
                return RedirectToAction(nameof(Index));
            }

            var p = new Post
            {
                UserId = user.Id,
                Text = post.Text,
                Date = DateTime.UtcNow
            };

            if (post.Media != null)
            {
                using var s = post.Media!.OpenReadStream();
                using var m = new MemoryStream();
                await s.CopyToAsync(m);

                p.Media = new Media
                {
                    FileName = post.Media.FileName,
                    ContentType = post.Media.ContentType,
                    Data = m.ToArray(),
                    DateAdded = DateTime.UtcNow
                };
            }

            await _dbContext.AddAsync(p);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
