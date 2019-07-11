using System.Collections.Generic;
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
        Task<TEntity> InsertAsync(TEntity entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task<long> BulkInsertAsync(IEnumerable<TEntity> entities);
    }
}
