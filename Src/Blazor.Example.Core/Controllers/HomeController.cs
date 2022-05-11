using Microsoft.AspNetCore.Mvc;

namespace Blazor.Example.Core.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
