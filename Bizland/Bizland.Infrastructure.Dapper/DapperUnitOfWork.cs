using Bizland.Domain.Core;
using Bizland.Infrastructure.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bizland.Infrastructure.Dapper
{
    public class DapperUnitOfWork : IUnitOfWork
    {
        private ConcurrentDictionary<string, object> _repositories = null;
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly IEnumerable<IDomainEventDispatcher> _eventBuses;

        public DapperUnitOfWork(ISqlConnectionFactory sqlConnectionFactory, IEnumerable<IDomainEventDispatcher> eventBuses)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _eventBuses = eventBuses;
        }

        public IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : class, IAggregateRoot
        {
            if (_repositories == null)
                _repositories = new ConcurrentDictionary<string, object>();

            var key = $"{typeof(TEntity)}-command";
            if (!_repositories.ContainsKey(key))
            {
                var repository = new GenericRepository<TEntity>(_sqlConnectionFactory, _eventBuses);
                _repositories[key] = repository;
            }

            return (IRepositoryAsync<TEntity>)_repositories[key];
        }

        public void Dispose()
        {
            if (_sqlConnectionFactory != null)
            {
                GC.SuppressFinalize(_sqlConnectionFactory);
            }
        }

        public IQueryRepository<TEntity> QueryRepository<TEntity>() where TEntity : class, IAggregateRoot
        {
            if (_repositories == null)
                _repositories = new ConcurrentDictionary<string, object>();

            var key = $"{typeof(TEntity)}-query";
            if (!_repositories.ContainsKey(key))
            {
                var repository = new GenericRepository<TEntity>(_sqlConnectionFactory, _eventBuses);
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
