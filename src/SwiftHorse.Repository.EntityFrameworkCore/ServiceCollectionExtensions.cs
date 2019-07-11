using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SwiftHorse.Repository.EntityFrameworkCore.Context;
using System;

namespace SwiftHorse.Repository.EntityFrameworkCore
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TDbContext"></typeparam>
        /// <param name="services"></param>
        /// <param name="optionsAction"></param>
        public static void AddRepository<TDbContext>(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction = null) where TDbContext : DbContext
        {
            services.AddDbContext<TDbContext>(optionsAction);
            services.AddScoped(typeof(IDbContextProvider<>), typeof(DbContextProvider<>));
        }
    }
}
