using Microsoft.AspNetCore.Mvc;
using SkiShop.Models;
using SkiShop.Services;
using log4net;
using log4net.Config;

namespace SkiShop.Controllers
{
    public class AddController : Controller
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(AddController));
        // main add page returns the view
        public IActionResult Index()
        {
            BasicConfigurator.Configure();
            log.Info("User Entered Add A Product");
            return View();
        }
        // when the add button is pressed this method is called and returns new view success
        public IActionResult Create(InventoryModel product)
        {
            log.Info("User Has Created A New Prdocut");
            SkiService skiService = new SkiService();
            skiService.InsertSki(product);
            return View("Success");
        }
    }
}
