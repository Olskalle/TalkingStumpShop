using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TalkingStumpShop.Models;

namespace TalkingStumpShop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductsService _service;

        public IndexModel(IProductsService service)
        {
            _service = service;
        }

        public List<Product> Products { get; set; } = new();

        public async void OnGet()
        {
            var products = await _service.GetAsync(new CancellationToken());
            Products = products.ToList();
        }
    }
}
