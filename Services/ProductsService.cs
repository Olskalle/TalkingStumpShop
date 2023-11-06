using System.Linq.Expressions;
using TalkingStumpShop.Models;

namespace TalkingStumpShop.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IGenericRepository<Product> _repository;
        private readonly ILogger<ProductsService>? _logger;

        public ProductsService(IGenericRepository<Product> repository, ILogger<ProductsService>? logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task CreateAsync(Product product, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await _repository.AddAsync(product, cancellationToken);
        }

        public async Task DeleteAsync(Product product, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await _repository.DeleteAsync(product, cancellationToken);
        }

        public async Task<IQueryable<Product>> GetAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var result = await _repository.GetAsync(cancellationToken);
            return result;
        }

        public async Task<IQueryable<Product>> GetAsync(Expression<Func<Product, bool>> predicate, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var result = await _repository.GetAsync(predicate, cancellationToken);
            return result;
        }

        public async Task UpdateAsync(Product product, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await _repository.UpdateAsync(product, cancellationToken);
        }
    }
}
