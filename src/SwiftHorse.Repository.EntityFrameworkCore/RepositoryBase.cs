using Microsoft.EntityFrameworkCore;
using SwiftHorse.Repository.EntityFrameworkCore.Context;
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
        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Table.FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<IList<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Table.Where(predicate).ToListAsync();
        }
    }
}
