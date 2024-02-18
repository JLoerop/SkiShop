using Microsoft.AspNetCore.Mvc;

namespace SkiShop.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
