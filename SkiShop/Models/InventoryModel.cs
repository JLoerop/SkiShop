namespace SkiShop.Models
{
    // main model for all of the skis and snowboard that is used throughout the program
    public class InventoryModel
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public string Condition { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }

        public InventoryModel(int id, int price, int length, int width, string condition, string brand, string type, string image) 
        {
            Id = id;
            Price = price;
            Length = length;
            Width = width;
            Condition = condition;
            Brand = brand;
            Type = type;
            Image = image;
        }
        public InventoryModel() { }
    }
}
