using Fannan.Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace Fannan.Web.Controllers
{
    [Route("api/medias")]
    public class MediaController(ApplicationDbContext dbContext) : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        [HttpGet("{mediaId:int}")]
        public async Task<IActionResult> Get([FromRoute] int mediaId)
        {
            var media = await _dbContext.Medias.FindAsync(mediaId);
            if (media == null)
            {
                return NotFound();
            }
            return File(media.Data, media.ContentType);
        }
    }
}
