namespace TalkingStumpShop.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string ImageFileName { get; set;} = null!;
    }
}
