using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace SwiftHorse.Repository.EntityFrameworkCore.Context
{
    internal class DbContextProvider<TDbContext> : IDbContextProvider<TDbContext> where TDbContext : DbContext
    {
        private readonly IServiceProvider _serviceProvider;
        private TDbContext _dbContext;

        public DbContextProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TDbContext GetDbContext()
        {
            return _dbContext ?? (_dbContext = _serviceProvider.GetService<TDbContext>());
        }
    }
}
