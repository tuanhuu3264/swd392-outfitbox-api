using Microsoft.EntityFrameworkCore.Query;
using StackExchange.Redis;
using System.Linq.Expressions;

namespace SWD392.OutfitBox.DataLayer.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Get();

        Task<TEntity?> GetById(object id, CancellationToken cancellationToken = default);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);


        Task Update(TEntity entity);

        void UpdateRange(params TEntity[] entities);


        Task Delete(TEntity entity);
        void DeleteRange(params TEntity[] entities);

        public Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> include = null, int? pageIndex = null, int? pageSize = null);
        public Task<int> Count(Expression<Func<TEntity, bool>> filter = null);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
        public Task<IEnumerable<TEntity>> GetStartEnd(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> include = null, int? started = null, int? ended = null);


    }
}