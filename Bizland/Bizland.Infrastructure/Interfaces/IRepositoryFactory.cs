using Bizland.Domain.Core;

namespace Bizland.Infrastructure.Interfaces
{
    public interface IRepositoryFactory
    {
        IQueryRepository<TEntity, TKey> QueryRepository<TEntity, TKey>() where TEntity : DomainEntity<TKey>;

        IRepositoryAsync<TEntity, TKey> RepositoryAsync<TEntity, TKey>() where TEntity : DomainEntity<TKey>;
    }
}