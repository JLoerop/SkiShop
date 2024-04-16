using Microsoft.AspNetCore.Mvc;
using SkiShop.Models;
using SkiShop.Services;
using log4net;
using log4net.Config;
namespace SkiShop.Controllers
{
    public class InventoryController : Controller
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(InventoryController));
        
        SkiService skiService = new SkiService();
        // main display of inventory
        public IActionResult Index()
        {
            BasicConfigurator.Configure();
            log.Info("User Entered The Inventory");
            return View("InventoryIndex", skiService.getInventory());
        }
        // method for when the delete button is clicked on a product
        public IActionResult Delete(int Id)
        {
            log.Info("User Deleted A Item");
            skiService.DeleteSki(Id);
            return View("InventoryIndex", skiService.getInventory());
        }
        // update method that brings to a new page to update the page
        public IActionResult Update(int Id) 
        {
            log.Info("User entered update product.");
            return View("Update", skiService.GetProductById(Id));
        }
        // method for when update is clicked in the update form
        public IActionResult Updateproduct(InventoryModel product)
        {
            log.Info("User updated a product");
            skiService.Update(product);
            return View("InventoryIndex", skiService.getInventory());
        }
    }
}
