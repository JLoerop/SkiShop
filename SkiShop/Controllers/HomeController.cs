using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Mvc;
using SkiShop.Models;
using System.Diagnostics;

namespace SkiShop.Controllers
{

    public class HomeController : Controller
    {
        // logging not used for cloud because of azure providing logging
        public static readonly ILog log = LogManager.GetLogger(typeof(HomeController));
        // home controller returns home page view
        public IActionResult Index()
        {
            BasicConfigurator.Configure();
            log.Info("User Entered Home Page");
            return View();
        }

    }
}