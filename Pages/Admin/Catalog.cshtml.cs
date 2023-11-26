using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TalkingStumpShop.Models;
using TalkingStumpShop.Services;

namespace TalkingStumpShop.Pages.Admin
{
    public class CatalogModel : PageModel
    {
        private readonly IProductsService _service;
        public CatalogModel(IProductsService service)
        {
            _service = service;
        }

        public List<Product> Products { get; set; }

        public async void OnGet()
        {
            var result = await _service.GetAsync(new CancellationToken());
            Products = result.ToList();
        }
    }
}
