using System;
using System.Collections.Generic;
using System.Text;
using SwiftHorse.Repository.EntityFrameworkCore.Context;

namespace SwiftHorse.Repository.EntityFrameworkCore.Test
{
    public class TestEntity
    {
        public Guid Id { get; set; }
    }

    public interface ITestRepository : IRepository<TestEntity>
    {
    }

    public class TestRepository : RepositoryBase<TestDbContext, TestEntity>, ITestRepository
    {
        public TestRepository(IDbContextProvider<TestDbContext> contextProvider) : base(contextProvider)
        {
        }
    }
}
