using Microsoft.AspNetCore.Mvc;
using SkiShop.Models;
using SkiShop.Services;

namespace SkiShop.Controllers
{
    public class InventoryController : Controller
    {
        SkiService skiService = new SkiService();
        // main display of inventory
        public IActionResult Index()
        {
            
            return View("InventoryIndex", skiService.getInventory());
        }
        // method for when the delete button is clicked on a product
        public IActionResult Delete(int Id)
        {
            skiService.DeleteSki(Id);
            return View("InventoryIndex", skiService.getInventory());
        }
        // update method that brings to a new page to update the page
        public IActionResult Update(int Id) 
        {
            return View("Update", skiService.GetProductById(Id));
        }
        // method for when update is clicked in the update form
        public IActionResult Updateproduct(InventoryModel product)
        {
            skiService.Update(product);
            return View("InventoryIndex", skiService.getInventory());
        }
    }
}
