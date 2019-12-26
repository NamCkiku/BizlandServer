using Bizland.Domain.Core;

namespace Bizland.Infrastructure.Interfaces
{
    public interface IRepositoryFactory
    {
        IQueryRepository<TEntity> QueryRepository<TEntity>() where TEntity : class, IAggregateRoot;
        IRepositoryWithIdAsync<TEntity, TId> RepositoryAsync<TEntity, TId>() where TEntity : class, IAggregateRootWithId<TId>;
        IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : class, IAggregateRoot;
    }
}