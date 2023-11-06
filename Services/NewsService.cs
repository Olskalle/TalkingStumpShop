using System.Linq.Expressions;
using TalkingStumpShop.Models;

namespace TalkingStumpShop.Services
{
    public class NewsService : INewsService
    {
        private readonly IGenericRepository<NewsArticle> _repository;
        private readonly ILogger<NewsService>? _logger;

        public NewsService(IGenericRepository<NewsArticle> repository, ILogger<NewsService>? logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public Task CreateAsync(NewsArticle article, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(NewsArticle article, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<NewsArticle>> GetAsync(CancellationToken cancellationToken)
        {
            return await _repository.GetAsync(cancellationToken);
        }

        public Task<IQueryable<NewsArticle>> GetAsync(Expression<Func<NewsArticle, bool>> predicate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(NewsArticle article, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public interface INewsService
    {
        Task CreateAsync(NewsArticle article, CancellationToken cancellationToken);
        Task<IQueryable<NewsArticle>> GetAsync(CancellationToken cancellationToken);
        Task<IQueryable<NewsArticle>> GetAsync(Expression<Func<NewsArticle, bool>> predicate, CancellationToken cancellationToken);
        Task UpdateAsync(NewsArticle article, CancellationToken cancellationToken);
        Task DeleteAsync(NewsArticle article, CancellationToken cancellationToken);
    }
}
