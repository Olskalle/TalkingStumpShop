using System.Linq.Expressions;
using TalkingStumpShop.Models;

namespace TalkingStumpShop.Services
{
    public interface IProductsService
    {
        Task CreateAsync(Product article, CancellationToken cancellationToken);
        Task<IQueryable<Product>> GetAsync(CancellationToken cancellationToken);
        Task<IQueryable<Product>> GetAsync(Expression<Func<Product, bool>> predicate, CancellationToken cancellationToken);
        Task UpdateAsync(Product article, CancellationToken cancellationToken);
        Task DeleteAsync(Product article, CancellationToken cancellationToken);
    }
}
