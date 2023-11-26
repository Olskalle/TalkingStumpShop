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

        public async Task CreateAsync(NewsArticle article, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _repository.AddAsync(article, cancellationToken);
        }

        public async Task DeleteAsync(NewsArticle article, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _repository.DeleteAsync(article, cancellationToken);
        }

        public async Task<IQueryable<NewsArticle>> GetAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _repository.GetAsync(cancellationToken);
            return result.OrderBy(x => x.CreationDate);
        }

        public async Task<IQueryable<NewsArticle>> GetAsync(Expression<Func<NewsArticle, bool>> predicate, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _repository.GetAsync(predicate, cancellationToken);
            return result.OrderBy(x => x.CreationDate);
        }

        public async Task UpdateAsync(NewsArticle article, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _repository.UpdateAsync(article, cancellationToken);
        }
    }
}
