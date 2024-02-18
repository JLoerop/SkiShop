namespace SkiShop.Models
{
    public class SkiModel
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public string Condition { get; set; }
        public string Brand { get; set; }
        public string Image { get; set; }
        public SkiModel(int id, int price, int length, int width, string condition, string brand, string image) 
        {
            Id = id;
            Price = price;
            Length = length;
            Width = width;
            Condition = condition;
            Brand = brand;
            Image = image;
        }
        public SkiModel() { }
    }
}
