using Bizland.Domain.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bizland.Infrastructure.Infrastructure
{
    public class RepositoryAsync<TDbContext, TEntity, TKey> : IRepositoryAsync<TEntity, TKey>, IDisposable
        where TDbContext : DbContext
        where TEntity : DomainEntity<TKey>
    {
        private readonly TDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public RepositoryAsync(TDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            var entry = _dbSet.Remove(entity);
            return await Task.FromResult(1); //TODO: find a better way
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var entry = _dbContext.Entry(entity);
            entry.State = EntityState.Modified;
            return await Task.FromResult(entry.Entity);
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

    }
}
