using System.Linq.Expressions;

namespace FAMS.Api.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Get();

        Task<TEntity?> GetById(object id, CancellationToken cancellationToken = default);

        Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        void Delete(params TEntity[] entities);

        void Update(params TEntity[] entities);

        void Delete(TEntity entity);

        void Update(TEntity entity);

        Task SaveChangesAsync(CancellationToken cancellationToken = default);

        public Task<IEnumerable<TEntity>?> Find(Expression<Func<TEntity, bool>>? filter = null,
            string includeProperties = "",
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null);

        public Task<TEntity?> FindOne(Expression<Func<TEntity, bool>>? filter = null, string includeProperties = "");

        public Task<bool> AddHashKey(TEntity entity, CancellationToken cancellationToken = default);
    }
}