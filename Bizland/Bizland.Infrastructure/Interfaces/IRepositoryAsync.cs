using System.Threading.Tasks;

namespace Bizland.Infrastructure
{
    public interface IRepositoryAsync<TEntity, in TKey> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<int> DeleteAsync(TEntity entity);
    }
}