﻿using Bizland.Domain.Core;
using System;
using System.Threading.Tasks;

namespace Bizland.Infrastructure
{
    public interface IRepositoryAsync<TEntity> : IRepositoryWithIdAsync<TEntity, Guid> where TEntity : IAggregateRoot
    {
    }

    public interface IRepositoryWithIdAsync<TEntity, TId> where TEntity : IAggregateRootWithId<TId>
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);
    }
}