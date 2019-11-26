using System.Linq;

namespace Bizland.Infrastructure.Interfaces
{
    public interface IQueryRepository<TEntity, TKey> where TEntity : class
    {
        IQueryable<TEntity> Queryable();
    }
}