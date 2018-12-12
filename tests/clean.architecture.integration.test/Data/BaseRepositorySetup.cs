using clean.architecture.core.Interfaces;
using clean.architecture.core.SharedKernel;
using clean.architecture.infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace clean.architecture.integration.test.Data
{
    public class BaseRepositorySetup<T> where T : BaseEntity
    {
        protected AppDbContext _dbContext;
        protected EfRepository<T> _repository;

        public BaseRepositorySetup()
        {
            var options = CreateNewContextOptions();
            var mockDispatcher = new Mock<IDomainEventDispatcher>();
            _dbContext = new AppDbContext(options, mockDispatcher.Object);
            _repository = new EfRepository<T>(_dbContext);
        }

        private DbContextOptions<AppDbContext> CreateNewContextOptions()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseInMemoryDatabase("clean.architecture")
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }
    }
}
