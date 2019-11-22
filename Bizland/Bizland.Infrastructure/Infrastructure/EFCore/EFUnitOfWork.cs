using Bizland.Domain.Core;
using Bizland.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bizland.Infrastructure.Infrastructure.EFCore
{
    public interface IEfUnitOfWork : IUnitOfWork { }

    public interface IEfUnitOfWork<TDbContext> : IUnitOfWork where TDbContext : DbContext { }

    public class EfUnitOfWork<TDbContext> : IEfUnitOfWork<TDbContext> where TDbContext : DbContext
    {
        private readonly TDbContext _context;
        private ConcurrentDictionary<string, object> _repositories;

        public EfUnitOfWork(TDbContext context)
        {
            _context = context;
        }

        public virtual int Commit()
        {
            return _context.SaveChanges();
        }

        public virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public IQueryRepository<TEntity, TKey> QueryRepository<TEntity, TKey>() where TEntity : DomainEntity<TKey>
        {
            if (_repositories == null)
                _repositories = new ConcurrentDictionary<string, object>();

            var key = $"{typeof(TEntity)}-query";
            if (!_repositories.ContainsKey(key))
            {
                var cachedRepo = new QueryRepository<TEntity, TKey>(_context);
                _repositories[key] = cachedRepo;
            }

            return (IQueryRepository<TEntity, TKey>)_repositories[key];
        }

        public IRepositoryAsync<TEntity, TKey> RepositoryAsync<TEntity, TKey>() where TEntity : DomainEntity<TKey>
        {
            if (_repositories == null) _repositories = new ConcurrentDictionary<string, object>();

            var key = $"{typeof(TEntity)}-command";
            if (!_repositories.ContainsKey(key))
                _repositories[key] = new RepositoryAsync<DbContext, TEntity, TKey>(_context);

            return (IRepositoryAsync<TEntity, TKey>)_repositories[key];
        }
    }
}
