using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SwiftHorse.Repository.EntityFrameworkCore
{
    /// <summary>
    /// 
    /// </summary>
    public partial class RepositoryBase<TDbContext, TEntity> : IRepository<TEntity>
        where TDbContext : DbContext
        where TEntity : class
    {
        private readonly IDbContextProvider<TDbContext> _contextProvider;

        public RepositoryBase(IDbContextProvider<TDbContext> contextProvider)
        {
            _contextProvider = contextProvider;
        }

        protected TDbContext DbContext => _contextProvider.GetDbContext();

        protected DbSet<TEntity> Table => DbContext.Set<TEntity>();
    }

    public partial class RepositoryBase<TDbContext, TEntity>
    {
        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
            return entity;
        }

        public virtual async Task<long> BulkInsertAsync(IEnumerable<TEntity> entities)
        {
            await Table.AddRangeAsync(entities);
            return entities.Count();
        }
    }

    public partial class RepositoryBase<TDbContext, TEntity>
    {
        protected virtual void Attach(TEntity entity)
        {
            var entry = DbContext.ChangeTracker.Entries().FirstOrDefault(ee => ee.Entity == entity);
            if (entry != null) { return; }

            Table.Attach(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;

            await Task.Yield();
        }

        public async Task BulkUpdateAsync(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                await UpdateAsync(entity);
            }
        }

        public Task BulkUpdateAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> sets)
        {
            throw new NotImplementedException();
        }
    }

    public partial class RepositoryBase<TDbContext, TEntity>
    {
        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Table.FirstOrDefaultAsync(predicate);
        }

        public async Task<IList<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Table.Where(predicate).ToListAsync();
        }

        public async Task<T> FirstOrDefaultAsync<T>(string sql, object param)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param)
        {
            throw new NotImplementedException();
        }
    }

    public partial class RepositoryBase<TDbContext, TEntity>
    {
        public async Task ExecuteAsync(string sql, object param)
        {
            throw new NotImplementedException();
        }
    }
}
