namespace TalkingStumpShop.Models
{
    public class NewsArticle
    {
        public long Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public string? ImageFileName { get; set; }
    }
}
