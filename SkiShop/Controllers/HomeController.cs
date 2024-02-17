using Microsoft.AspNetCore.Mvc;
using SkiShop.Models;
using System.Diagnostics;

namespace SkiShop.Controllers
{
    public class HomeController : Controller
    {
    
        public IActionResult Index()
        {
            return View();
        }

    }
}