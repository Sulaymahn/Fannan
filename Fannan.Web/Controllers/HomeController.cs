using Fannan.Web.Data;
using Fannan.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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
