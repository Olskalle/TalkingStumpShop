using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TalkingStumpShop.Models;
using TalkingStumpShop.Services;

namespace TalkingStumpShop.Pages
{
    public class AdminProductsModel : PageModel
    {
        private readonly IProductsService _service;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminProductsModel(IProductsService service, IWebHostEnvironment webHostEnvironment)
        {
            _service = service;
            _webHostEnvironment = webHostEnvironment;
        }

        public List<Product> Products { get; set; } = new();

        public async void OnGet()
        {
            var products = await _service.GetAsync(new CancellationToken());
            Products = products.ToList();
        }

        public async Task<IActionResult> OnPostNewAsync()
        {
            return RedirectToPage("/AdminProductEdit");
        }

        public async Task<IActionResult> OnPostEditAsync(int productId, Product product, IFormFile image, CancellationToken token)
        {
            if (token.IsCancellationRequested) return Page();

            if (productId != product.Id) return BadRequest();

            var existingProduct = await _service.GetAsync(x => x.Id == productId, token);
            if (existingProduct is null) return BadRequest();

            if (image is null)
            {
                product.ImageFileName = existingProduct.First().ImageFileName;
            }
            else
            {
                var uniqueFileName = Path.GetRandomFileName();
                var file = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot/catalog", uniqueFileName);
                using (var fileStream = System.IO.File.Create(file))
                {
                    await image.CopyToAsync(fileStream);
                }
                product.ImageFileName = uniqueFileName;
            }

            await _service.UpdateAsync(product, token);

            //return Page();
            return RedirectToPage("/AdminProducts");
        }
    }
}
