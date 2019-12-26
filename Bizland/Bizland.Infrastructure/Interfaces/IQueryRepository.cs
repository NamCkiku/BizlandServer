using Bizland.Domain.Core;
using System;
using System.Linq;

namespace Bizland.Infrastructure.Interfaces
{
    public interface IQueryRepository<TEntity> : IQueryRepositoryWithId<TEntity, Guid> where TEntity : IAggregateRoot
    {
    }

    public interface IQueryRepositoryWithId<TEntity, TId> where TEntity : IAggregateRootWithId<TId>
    {
        IQueryable<TEntity> Queryable();
    }
}