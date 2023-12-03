using System.ComponentModel.DataAnnotations;

namespace TalkingStumpShop.Models
{
    public class Product
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string? ImageFileName { get; set;}
    }
}
