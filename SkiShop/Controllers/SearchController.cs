using Microsoft.AspNetCore.Mvc;
using SkiShop.Services;

namespace SkiShop.Controllers
{
    public class SearchController : Controller
    {
        SkiService skiService = new SkiService();
        // loading default search page
        public IActionResult Index()
        {
            return View();
        }
        // activate search method and display results
        public IActionResult SearchResults(string searchTerm)
        {
            return View("InventoryIndex", skiService.Search(searchTerm));

        }
    }
}
