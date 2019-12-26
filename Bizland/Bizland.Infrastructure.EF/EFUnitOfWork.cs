using Bizland.Domain.Core;
using Bizland.Infrastructure.Interfaces;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bizland.Infrastructure.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ConcurrentDictionary<string, object> _repositories = null;
        private readonly IEnumerable<IDomainEventDispatcher> _eventBuses;

        private readonly DbContext _dbContext;

        public EFUnitOfWork(DbContext dbContext, IEnumerable<IDomainEventDispatcher> eventBuses)
        {
            _dbContext = dbContext;
            _eventBuses = eventBuses;
        }

        public IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : class, IAggregateRoot
        {
            if (_repositories == null)
                _repositories = new ConcurrentDictionary<string, object>();

            var key = $"{typeof(TEntity)}-command";
            if (!_repositories.ContainsKey(key))
            {
                var repository = new RepositoryAsync<TEntity>(_dbContext, _eventBuses);
                _repositories[key] = repository;
            }

            return (IRepositoryAsync<TEntity>)_repositories[key];
        }

        public void Dispose()
        {
        }

        public IQueryRepository<TEntity> QueryRepository<TEntity>() where TEntity : class, IAggregateRoot
        {
            if (_repositories == null)
                _repositories = new ConcurrentDictionary<string, object>();

            var key = $"{typeof(TEntity)}-query";
            if (!_repositories.ContainsKey(key))
            {
                var repository = new RepositoryAsync<TEntity>(_dbContext, _eventBuses);
                _repositories[key] = repository;
            }

            return (IQueryRepository<TEntity>)_repositories[key];
        }

        public IRepositoryWithIdAsync<TEntity, TId> RepositoryAsync<TEntity, TId>() where TEntity : class, IAggregateRootWithId<TId>
        {
            throw new NotImplementedException();
        }
    }
}