namespace SwiftHorse.Repository.EntityFrameworkCore.Context
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TDbContext"></typeparam>
    public interface IDbContextProvider<TDbContext>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        TDbContext GetDbContext();
    }
}
