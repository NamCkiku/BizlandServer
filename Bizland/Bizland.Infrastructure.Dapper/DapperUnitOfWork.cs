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
    public class DapperUnitOfWork : IDapperUnitOfWork
    {
        private ConcurrentDictionary<string, object> _repositories = null;
        public ISqlConnectionFactory SqlConnectionFactory { get; }

        public DapperUnitOfWork(ISqlConnectionFactory sqlConnectionFactory)
        {
            SqlConnectionFactory = sqlConnectionFactory;
        }

        public IQueryRepository<TEntity, Tkey> QueryRepository<TEntity, Tkey>() where TEntity : DomainEntity<Tkey>
        {
            if (_repositories == null)
                _repositories = new ConcurrentDictionary<string, object>();

            var key = $"{typeof(TEntity)}-query";
            if (!_repositories.ContainsKey(key))
            {
                var cachedRepo = new GenericRepository<TEntity, Tkey>(SqlConnectionFactory);
                _repositories[key] = cachedRepo;
            }

            return (IQueryRepository<TEntity, Tkey>)_repositories[key];
        }

        public IRepositoryAsync<TEntity, Tkey> RepositoryAsync<TEntity, Tkey>() where TEntity : DomainEntity<Tkey>
        {
            if (_repositories == null)
                _repositories = new ConcurrentDictionary<string, object>();

            var key = $"{typeof(TEntity)}-command";
            if (!_repositories.ContainsKey(key))
            {
                var cachedRepo = new GenericRepository<TEntity, Tkey>(SqlConnectionFactory);
                _repositories[key] = cachedRepo;
            }

            return (IRepositoryAsync<TEntity, Tkey>)_repositories[key];
        }

        public int Commit()
        {
            //TODO: just for compatible with the IUnitOfWork interface
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            //TODO: just for compatible with the IUnitOfWork interface
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (SqlConnectionFactory != null)
            {
                GC.SuppressFinalize(SqlConnectionFactory);
            }
        }
    }
}
