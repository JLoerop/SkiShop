using Microsoft.AspNetCore.Mvc;
using SkiShop.Models;
using SkiShop.Services;

namespace SkiShop.Controllers
{
    public class AddController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add(InventoryModel product)
        {
            SkiService skiService = new SkiService();
            skiService.InsertSki(product);
            return View("Success");
        }
    }
}
