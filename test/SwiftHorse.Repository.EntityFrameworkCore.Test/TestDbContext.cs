using Microsoft.EntityFrameworkCore;

namespace SwiftHorse.Repository.EntityFrameworkCore.Test
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {

        }

        public DbSet<TestEntity> Tests { get; set; }
    }
}
