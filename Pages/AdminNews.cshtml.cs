using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using System.Threading;
using TalkingStumpShop.Models;
using TalkingStumpShop.Services;
using static System.Net.Mime.MediaTypeNames;

namespace TalkingStumpShop.Pages
{
    [Authorize]
    public class AdminNewsModel : PageModel
    {
        private readonly INewsService _service;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminNewsModel(INewsService service, IWebHostEnvironment webHostEnvironment)
        {
            _service = service;
            _webHostEnvironment = webHostEnvironment;
        }

        public List<NewsArticle>? NewsArticles { get; set; }
        [BindProperty]
        public NewsArticle NewArticle { get; set; } = new();

        public async Task<IActionResult> OnGet(CancellationToken token)
        {
            if (!HttpContext.Request.Cookies.Any()) return Unauthorized();
            var news = await _service.GetAsync(token);
            NewsArticles = news.ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostNewAsync(IFormFile image, CancellationToken token)
        {
            if (!ModelState.IsValid)
            {
                await OnGet(token);
                return Page();
            }

            if (NewArticle is null) return Page();
            if (image is not null)
            {
                var imageExtension = image.FileName.Split('.').Last();
                var uniqueFileName = Path.GetRandomFileName() + $".{imageExtension}";
                var file = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot/news", uniqueFileName);
                using (var fileStream = System.IO.File.Create(file))
                {
                    await image.CopyToAsync(fileStream);
                }
                NewArticle.ImageFileName = uniqueFileName;
            }

            await _service.CreateAsync(NewArticle, token);
            return RedirectToPage("/AdminNews");
        }

        public async Task<IActionResult> OnPostEditAsync(int articleId, NewsArticle article, IFormFile image, CancellationToken token)
        {
            if (token.IsCancellationRequested) return Page();

            if (articleId != article.Id) return BadRequest();

            var existingArticle = await _service.GetAsync(x => x.Id == articleId, token);
            if (existingArticle is null) return BadRequest();

            article.CreationDate = existingArticle.First().CreationDate;
            if (image is null)
            {
                article.ImageFileName = existingArticle.First().ImageFileName;
            }
            else
            {
                var imageExtension = image.FileName.Split('.').Last();
                var uniqueFileName = Path.GetRandomFileName() + $".{imageExtension}";
                var file = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot/news", uniqueFileName);
                using (var fileStream = System.IO.File.Create(file))
                {
                    await image.CopyToAsync(fileStream);
                }
                article.ImageFileName = uniqueFileName;
            }

            await _service.UpdateAsync(article, token);
            return RedirectToPage("/AdminNews");
        }

        public async Task<IActionResult> OnPostDelete(int articleId, CancellationToken token)
        {
            if (token.IsCancellationRequested) return Page();

            var articleToDelete = await _service.GetAsync(x => x.Id == articleId, token);

            if (articleToDelete is null || articleToDelete.Count() != 1) return BadRequest();

            await _service.DeleteAsync(articleToDelete.First(), token);

            return RedirectToPage("/AdminNews");
        }
    }
}
