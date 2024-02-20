using SkiShop.Models;

namespace SkiShop.Services
{
    public class SkiService
    {
        // the ski service which access' the data access object and calls their methods
        SkiDAO skiDao = new SkiDAO();
        public List<InventoryModel> getInventory()
        {
            return skiDao.getInventory();
        }
        public bool InsertSki(InventoryModel inventory)
        {
            return skiDao.InsertSki(inventory);
        }
        public bool DeleteSki(int Id)
        {
            return skiDao.Delete(Id);
        }
        public InventoryModel GetProductById(int Id)
        {
            return skiDao.GetProductById(Id);
        }
        public int Update(InventoryModel inventory)
        {
            return skiDao.Update(inventory);
        }
        public List<InventoryModel> Search(string searchterm)
        {
            return skiDao.SearchProducts(searchterm);
        }
    }
}
