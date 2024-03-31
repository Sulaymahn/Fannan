using Fannan.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fannan.Web.Controllers
{
    public class FeedController(ApplicationDbContext dbContext) : Controller
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public async Task<IActionResult> Index()
        {
            return View(await _dbContext.Posts
                .AsNoTracking()
                .Include(p => p.Likes)
                .Include(p => p.Media)
                .Include(p => p.User)
                .Include(p => p.Comments)
                .ThenInclude(c => c.Replies)
                .Include(p => p.Comments)
                .ThenInclude(c => c.User)
                .ToListAsync());
        }

        public async Task<IActionResult> NewPost()
        {
            return Ok(await Task.Run(() => ""));
        }
    }
}
