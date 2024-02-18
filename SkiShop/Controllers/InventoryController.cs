using Microsoft.AspNetCore.Mvc;

namespace SkiShop.Controllers
{
    public class InventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
