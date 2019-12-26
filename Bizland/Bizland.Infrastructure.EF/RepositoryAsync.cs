using Bizland.Domain.Core;
using Bizland.Domain.Core.Models;
using Bizland.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bizland.Infrastructure.EF
{
    public class RepositoryAsync<TEntity> : IQueryRepository<TEntity>, IRepositoryAsync<TEntity> where TEntity : class, IAggregateRoot
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        private readonly IEnumerable<IDomainEventDispatcher> _eventBuses;

        public RepositoryAsync(DbContext dbContext, IEnumerable<IDomainEventDispatcher> eventBuses)
        {
            _dbContext = dbContext;
            _eventBuses = eventBuses;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> Queryable()
        {
            return _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await DispatchUncommittedEvents(entity);

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var entry = _dbContext.Entry(entity);
            entry.State = EntityState.Modified;
            await DispatchUncommittedEvents(entity);
            return await Task.FromResult(entry.Entity);
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            var entry = _dbSet.Remove(entity);
            await DispatchUncommittedEvents(entity);
            return await Task.FromResult(entry.Entity);
        }

        private async Task DispatchUncommittedEvents(TEntity entity)
        {
            foreach (var @event in entity.GetUncommittedEvents())
            {
                var repo = _dbContext.Set<OutboxMessage>();
                var outbox = new OutboxMessage(@event);
                await repo.AddAsync(outbox);
                _eventBuses.Select(b => b.Dispatch(@event)).ToList();
            }
            await _dbContext.SaveChangesAsync();
            entity.ClearUncommittedEvents();
        }
    }
}