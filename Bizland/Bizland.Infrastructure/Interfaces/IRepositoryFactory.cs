using Bizland.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bizland.Infrastructure.Interfaces
{
    public interface IRepositoryFactory
    {
        IQueryRepository<TEntity, TKey> QueryRepository<TEntity, TKey>() where TEntity : DomainEntity<TKey>;
        IRepositoryAsync<TEntity, TKey> RepositoryAsync<TEntity, TKey>() where TEntity : DomainEntity<TKey>;
    }
}
