
using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.DataLayer.Databases.Redis;
using SWD392.OutfitBox.DataLayer.Interfaces;
using System.Linq.Expressions;

namespace SWD392.OutfitBox.DataLayer.Repositories
    {
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly Context _context;
        private readonly DbSet<TEntity> _dbSet;

        public Context Context { get; }

        public BaseRepository(Context context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
           var result = await _dbSet.AddAsync(entity);
           await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();

        }

        public void Delete(params TEntity[] entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>?> Find(Expression<Func<TEntity, bool>>? filter = null,
            string includeProperties = "", Func<IQueryable<TEntity>,
                IOrderedQueryable<TEntity>>? orderBy = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<TEntity?> FindOne(Expression<Func<TEntity, bool>>? filter = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split
                         (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return await query.FirstOrDefaultAsync();

        }

        public IQueryable<TEntity> Get()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<TEntity?> GetById(object id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            
            await _context.SaveChangesAsync(cancellationToken);
            
        }

        public void Update(params TEntity[] entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public TEntity Update(TEntity entity)
        {
            var entityEntry = _dbSet.Update(entity);
            return entityEntry.Entity;
        }
        public async Task<bool> AddHashKey(TEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                var existingEntry = _context.ChangeTracker.Entries<TEntity>()
           .SingleOrDefault(e =>
               e.Entity.GetType() == entity.GetType() &&
               e.Properties.Any(p => p.Metadata.IsKey() && Equals(p.CurrentValue, entity.GetType().GetProperty(p.Metadata.Name)?.GetValue(entity))));

                if (existingEntry != null)
                {
                    // Entity with the same key values is being tracked, update its properties
                    existingEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    // Entity is not being tracked, add it
                    await _dbSet.AddAsync(entity, cancellationToken);
                }

                await _context.SaveChangesAsync(cancellationToken);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
