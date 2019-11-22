using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bizland.Infrastructure.Interfaces
{
    public interface IQueryRepository<TEntity, TKey> where TEntity : class
    {
        IQueryable<TEntity> Queryable();
    }
}
