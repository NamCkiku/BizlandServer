using Bizland.Domain.Core;
using Bizland.Domain.Entities;
using Bizland.Infrastructure.Configurations;
using Bizland.Infrastructure.Extensions;
using Bizland.Infrastructure.Helper;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bizland.Infrastructure.DBContext
{
    public abstract class AppDbContext : DbContext
    {
        private readonly IDomainEventDispatcher _eventBus = null;
        public AppDbContext(DbContextOptions options, IDomainEventDispatcher eventBus = null) : base(options)
        {
            _eventBus = eventBus ?? new MemoryDomainEventDispatcher();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var result = base.SaveChangesAsync(cancellationToken);
            SaveChangesWithEvents(_eventBus);
            return result;
        }

        public override int SaveChanges()
        {
            var result = base.SaveChanges();
            SaveChangesWithEvents(_eventBus);
            return result;
        }

        private void SaveChangesWithEvents(IDomainEventDispatcher domainEventDispatcher)
        {
            System.Collections.Generic.IEnumerable<EntityEntry> modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);

            foreach (EntityEntry item in modified)
            {
                if (item.Entity is IDateTracking changedOrAddedItem)
                {
                    if (item.State == EntityState.Added)
                    {
                        changedOrAddedItem.DateCreated = DateTime.Now;
                    }
                    changedOrAddedItem.DateModified = DateTime.Now;
                }
            }
            var entities = ChangeTracker.Entries().Select(e => e.Entity);

            entities
                .Where(e =>
                    !e.GetType().BaseType.IsGenericType &&
                    typeof(AggregateRootBase).IsAssignableFrom(e.GetType()))
                .Select(aggregateRoot =>
                {
                    var events = ((IAggregateRoot)aggregateRoot).GetUncommittedEvents();

                    foreach (var domainEvent in events)
                        domainEventDispatcher.Dispatch(domainEvent);

                    ((IAggregateRoot)aggregateRoot).GetUncommittedEvents().Clear();
                    return aggregateRoot;
                })
                .ToArray();

            entities
                .Where(e =>
                    e.GetType().BaseType.IsGenericType &&
                    typeof(AggregateRootWithIdBase<>).IsAssignableFrom(e.GetType().BaseType.GetGenericTypeDefinition()))
                .Select(aggregateRoot =>
                {
                    //todo: need a better code to avoid dynamic
                    var events = ((dynamic)aggregateRoot).GetUncommittedEvents();

                    foreach (var domainEvent in events)
                        domainEventDispatcher.Dispatch(domainEvent);

                    ((dynamic)aggregateRoot).GetUncommittedEvents().Clear();
                    return aggregateRoot;
                })
                .ToArray();
        }
    }
}