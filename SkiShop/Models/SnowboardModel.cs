namespace SkiShop.Models
{
    public class SnowboardModel
    {
        public int Id { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public string Brand { get; set; }
        public string Condition { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }

        public SnowboardModel(int id, int length, int width, string brand, string condition, int price, string image) 
        { 
            Id= id;
            Length = length;
            Width = width;
            Brand = brand;
            Condition = condition;
            Price = price;
            Image = image;
        }
        public SnowboardModel() { }
    }
}
