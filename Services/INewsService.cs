using System.Linq.Expressions;
using TalkingStumpShop.Models;

namespace TalkingStumpShop.Services
{
    public interface INewsService
    {
        Task CreateAsync(NewsArticle article, CancellationToken cancellationToken);
        Task<IQueryable<NewsArticle>> GetAsync(CancellationToken cancellationToken);
        Task<IQueryable<NewsArticle>> GetAsync(Expression<Func<NewsArticle, bool>> predicate, CancellationToken cancellationToken);
        Task UpdateAsync(NewsArticle article, CancellationToken cancellationToken);
        Task DeleteAsync(NewsArticle article, CancellationToken cancellationToken);
    }
}
