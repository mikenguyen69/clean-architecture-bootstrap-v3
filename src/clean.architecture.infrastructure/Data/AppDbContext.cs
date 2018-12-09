using clean.architecture.core.Entities;
using clean.architecture.core.Interfaces;
using clean.architecture.core.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace clean.architecture.infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        private IDomainEventDispatcher _dispatcher;

        public AppDbContext(DbContextOptions<AppDbContext> options, IDomainEventDispatcher dispatcher) 
            : base(options)
        {
            _dispatcher = dispatcher;
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }

        public override int SaveChanges()
        {
            int result = base.SaveChanges();

            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(x => x.Entity)
                .Where(x => x.Events.Any())
                .ToArray();

            foreach(var entity in entitiesWithEvents)
            {
                var events = entity.Events.ToArray();
                entity.Events.Clear();

                foreach(var domainEvent in events)
                {
                    _dispatcher.Dispatch(domainEvent);
                }
            }

            return result;
        }
    }
}
