using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TalkingStumpShop.Models;
using TalkingStumpShop.Services;

namespace TalkingStumpShop.Pages
{
    public class AdminProductEditModel : PageModel
    {
        private readonly IProductsService _service;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminProductEditModel(IProductsService service, IWebHostEnvironment webHostEnvironment)
        {
            _service = service;
            _webHostEnvironment = webHostEnvironment;
        }

        public Product Product { get; set; } = new();

        [BindProperty]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "jpg,png,gif,jpeg,bmp,svg")]
        public IFormFile? Image { get; set; }

        public async Task OnGet(int? id)
        {
            var result = await _service.GetAsync(x => x.Id == id, new CancellationToken());

            if (result.Count() != 1)
            {
                Product = new Product();
                return;
            }

            Product = result.First();
        }

        public async Task<IActionResult> OnPost()
        {
            if (Image is not null)
            {
                var uniqueFileName = Guid.NewGuid().ToString() + Image.FileName;
                var file = Path.Combine(_webHostEnvironment.ContentRootPath, "products", uniqueFileName);
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostUpload()
        {
            var image = Image;
            //if (!ModelState.IsValid)
            //{
            //    Result = "Please correct the form.";

            //    return Page();
            //}

            //var formFileContent =
            //    await FileHelpers.ProcessFormFile<BufferedSingleFileUploadPhysical>(
            //        FileUpload.FormFile, ModelState, _permittedExtensions,
            //        _fileSizeLimit);

            //if (!ModelState.IsValid)
            //{
            //    Result = "Please correct the form.";

            //    return Page();
            //}

            //// For the file name of the uploaded file stored
            //// server-side, use Path.GetRandomFileName to generate a safe
            //// random file name.
            //var trustedFileNameForFileStorage = Path.GetRandomFileName();
            //var filePath = Path.Combine(
            //    _targetFilePath, trustedFileNameForFileStorage);

            //// **WARNING!**
            //// In the following example, the file is saved without
            //// scanning the file's contents. In most production
            //// scenarios, an anti-virus/anti-malware scanner API
            //// is used on the file before making the file available
            //// for download or for use by other systems. 
            //// For more information, see the topic that accompanies 
            //// this sample.

            //using (var fileStream = System.IO.File.Create(filePath))
            //{
            //    await fileStream.WriteAsync(formFileContent);

            //    // To work directly with a FormFile, use the following
            //    // instead:
            //    //await FileUpload.FormFile.CopyToAsync(fileStream);
            //}

            return RedirectToPage("./Index");
        }
    }
}
