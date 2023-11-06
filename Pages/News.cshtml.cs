using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TalkingStumpShop.Models;
using TalkingStumpShop.Services;

namespace TalkingStumpShop.Pages
{
    public class NewsModel : PageModel
    {
        private readonly INewsService _service;
        public NewsModel(INewsService service)
        {
            _service = service;
        }

        public List<NewsArticle> Articles { get; set; }

        public async void OnGet()
        {
            var result = await _service.GetAsync(new CancellationToken());
            Articles = result.ToList();
        }
    }
}
