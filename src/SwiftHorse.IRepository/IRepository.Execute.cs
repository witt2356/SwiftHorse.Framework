using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwiftHorse
{
    public partial interface IRepository<TEntity> : IRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        Task ExecuteAsync(string sql, object param);
    }
}
