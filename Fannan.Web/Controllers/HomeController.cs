using Microsoft.AspNetCore.Mvc;

namespace Fannan.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(User.Identity?.IsAuthenticated);
        }
    }
}
