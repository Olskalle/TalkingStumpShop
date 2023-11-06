using System.Linq.Expressions;
using TalkingStumpShop.Models;

namespace TalkingStumpShop
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

        public Task CreateAsync(Product article, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Product article, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<Product>> GetAsync(CancellationToken cancellationToken)
        {
            var result = await _repository.GetAsync(cancellationToken);
            return result;
        }

        public Task<IQueryable<Product>> GetAsync(Expression<Func<Product, bool>> predicate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product article, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public interface IProductsService
    {
        Task CreateAsync(Product article, CancellationToken cancellationToken);
        Task<IQueryable<Product>> GetAsync(CancellationToken cancellationToken);
        Task<IQueryable<Product>> GetAsync(Expression<Func<Product, bool>> predicate, CancellationToken cancellationToken);
        Task UpdateAsync(Product article, CancellationToken cancellationToken);
        Task DeleteAsync(Product article, CancellationToken cancellationToken);
    }
}
