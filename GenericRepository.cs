using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TalkingStumpShop
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        private readonly WebsiteContext _context;
        private DbSet<TEntity> _entitySet;
        private readonly ILogger<GenericRepository<TEntity>> _logger;

        public GenericRepository(WebsiteContext context, ILogger<GenericRepository<TEntity>> logger)
        {
            _context = context;
            _entitySet = _context.Set<TEntity>();
            _logger = logger;
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await _entitySet.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            _entitySet.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IQueryable<TEntity>> GetAsync(CancellationToken cancellationToken)
        {
            var result = _entitySet
                .AsNoTracking()
                .AsQueryable();
            return await Task.FromResult(result);
        }

        public async Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            var result = _entitySet
                .AsNoTracking()
                .Where(predicate)
                .AsQueryable();
            return await Task.FromResult(result);
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            _entitySet.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }

    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity, CancellationToken cancellationToken);
        Task<IQueryable<TEntity>> GetAsync(CancellationToken cancellationToken);
        Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
    }
}
