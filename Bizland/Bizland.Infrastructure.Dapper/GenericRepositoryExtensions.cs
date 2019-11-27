using Bizland.Domain.Core;
using Bizland.Infrastructure.Dapper.DapperCRUD;
using Bizland.Infrastructure.Interfaces;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bizland.Infrastructure.Dapper
{
    public static class GenericRepositoryExtensions
    {
        public static async Task<TEntity> GetByIdAsync<TEntity, TKey>(this IQueryRepository<TEntity, TKey> repo, TKey id)
            where TEntity : DomainEntity<TKey>
        {
            if (!(repo is GenericRepository<TEntity, TKey> genericRepo))
            {
                throw new System.Exception("Make sure your IQueryRepository<TEntity, TId> is a GenericRepository<TEntity, TId> instance.");
            }

            using var conn = genericRepo.SqlConnectionFactory.GetOpenConnection();
            var entities = await conn.GetListAsync<TEntity>(new { id });
            return entities.FirstOrDefault();
        }

        public static async Task<IReadOnlyCollection<TEntity>> GetByConditionAsync<TEntity, TKey>(this IQueryRepository<TEntity, TKey> repo, object whereConditions)
            where TEntity : DomainEntity<TKey>
        {
            if (!(repo is GenericRepository<TEntity, TKey> genericRepo))
            {
                throw new System.Exception("Make sure your IQueryRepository<TEntity, TId> is a GenericRepository<TEntity, TId> instance.");
            }

            using var conn = genericRepo.SqlConnectionFactory.GetOpenConnection();
            var entities = await conn.GetListAsync<TEntity>(whereConditions);
            return entities.ToList();
        }
    }
}