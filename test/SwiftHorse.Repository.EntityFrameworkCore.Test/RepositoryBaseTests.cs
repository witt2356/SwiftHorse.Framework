using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SwiftHorse.Repository.EntityFrameworkCore.Test
{
    [TestClass]
    public class RepositoryBaseTests
    {
        private readonly ITestRepository _repository;

        public RepositoryBaseTests()
        {
            var services = new ServiceCollection();
            services.AddRepository<TestDbContext>((builder) => builder.UseInMemoryDatabase("TestDb"));
            services.AddScoped<ITestRepository, TestRepository>();
            var serviceProvider = services.BuildServiceProvider();
            _repository = serviceProvider.GetService<ITestRepository>();
        }

        [TestMethod]
        public async Task InsertAsync()
        {
            var entity = await _repository.InsertAsync(new TestEntity());
            Assert.AreNotEqual(Guid.Empty, entity.Id);
        }

        [TestMethod]
        public async Task BulkInsertAsync()
        {
            var count = await _repository.BulkInsertAsync(new[] { new TestEntity() });
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public async Task FirstOrDefaultAsync()
        {
            var entity = await _repository.InsertAsync(new TestEntity());

            var find = await _repository.FirstOrDefaultAsync(x => x.Id == entity.Id);
            //Assert.AreEqual(entity.Id, find.Id);
        }

        [TestMethod]
        public async Task QueryAsync()
        {
            var entity = await _repository.InsertAsync(new TestEntity());

            var entities = await _repository.QueryAsync(x => x.Id == entity.Id);
            //Assert.AreEqual(1, entities.Count);
            //Assert.AreEqual(entity.Id, entities.First().Id);
        }
    }
}
