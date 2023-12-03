using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TalkingStumpShop.Models;
using TalkingStumpShop.Services;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;

namespace TalkingStumpShop.Pages
{
    [Authorize]
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

        [BindProperty]
        public Product NewProduct { get; set; } = new();

        [BindProperty]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public string Price { get; set; }

        public async Task OnGet()
        {
            var products = await _service.GetAsync(new CancellationToken());
            Products = products.ToList();
        }

        public async Task<IActionResult> OnPostNewAsync(IFormFile image, CancellationToken token)
        {
            if (!ModelState.IsValid)
            {
                await OnGet();
                return Page();
            }

            if (NewProduct is null) return Page();
            if (image is not null)
            {
                var imageExtension = image.FileName.Split('.').Last();
                var uniqueFileName = Path.GetRandomFileName() + $".{imageExtension}";
                var file = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot/catalog", uniqueFileName);
                using (var fileStream = System.IO.File.Create(file))
                {
                    await image.CopyToAsync(fileStream);
                }
                NewProduct.ImageFileName = uniqueFileName;
            }
            if (decimal.TryParse(Price, NumberStyles.Any, CultureInfo.InvariantCulture, out var price))
            {
                NewProduct.Price = price;
            }

            await _service.CreateAsync(NewProduct, token);
            return RedirectToPage("/AdminProducts");
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
                var imageExtension = image.FileName.Split('.').Last();
                var uniqueFileName = Path.GetRandomFileName() + $".{imageExtension}";
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

        public async Task<IActionResult> OnPostDeleteAsync(int productId, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return Page();

            var productToDelete = await _service.GetAsync(x => x.Id == productId, cancellationToken);

            if (productToDelete is null || productToDelete.Count() != 1) return BadRequest();

            await _service.DeleteAsync(productToDelete.First(), cancellationToken);

            return RedirectToPage("/AdminProducts");
        }
    }
}
