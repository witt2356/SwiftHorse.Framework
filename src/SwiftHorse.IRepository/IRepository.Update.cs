using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SwiftHorse
{
    public partial interface IRepository<TEntity> : IRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task BulkUpdateAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="sets"></param>
        /// <returns></returns>
        Task BulkUpdateAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> sets);
    }
}
