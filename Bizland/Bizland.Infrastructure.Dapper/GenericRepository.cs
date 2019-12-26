using Bizland.Domain.Core;
using Bizland.Infrastructure.Dapper.DapperCRUD;
using Bizland.Infrastructure.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bizland.Infrastructure.Dapper
{
    public class GenericRepository<TEntity> : IQueryRepository<TEntity>, IRepositoryAsync<TEntity> where TEntity : class, IAggregateRoot
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly IEnumerable<IDomainEventDispatcher> _eventBuses;

        public GenericRepository(ISqlConnectionFactory sqlConnectionFactory, IEnumerable<IDomainEventDispatcher> eventBuses)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _eventBuses = eventBuses;
        }

        public IQueryable<TEntity> Queryable()
        {
            using var conn = _sqlConnectionFactory.GetOpenConnection();
            var entities = conn.GetList<TEntity>();
            return entities.AsQueryable();
        }

        private async Task<TEntity> GetByIdAsync(Guid id)
        {
            using var conn = _sqlConnectionFactory.GetOpenConnection();
            var entities = await conn.GetListAsync<TEntity>(new { id });
            return entities.FirstOrDefault();
        }

        public async Task<IReadOnlyCollection<TEntity>> GetByConditionAsync(object whereConditions)
        {
            using var conn = _sqlConnectionFactory.GetOpenConnection();
            var entities = await conn.GetListAsync<TEntity>(whereConditions);
            return entities.ToList();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            using var conn = _sqlConnectionFactory.GetOpenConnection();
            var newId = await conn.InsertAsync<Guid, TEntity>(entity);

            DispatchUncommittedEvents(entity);

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            using var conn = _sqlConnectionFactory.GetOpenConnection();
            var numberRecordAffected = await conn.UpdateAsync(entity);
            if (numberRecordAffected <= 0)
            {
                throw new Exception("Could not update record to the database.");
            }

            DispatchUncommittedEvents(entity);

            return await GetByIdAsync(entity.Id);
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            using var conn = _sqlConnectionFactory.GetOpenConnection();
            await conn.DeleteAsync(entity);

            DispatchUncommittedEvents(entity);

            return entity;
        }

        private void DispatchUncommittedEvents(TEntity entity)
        {
            foreach (var @event in entity.GetUncommittedEvents())
            {
                _eventBuses.Select(b => b.Dispatch(@event)).ToList();
            }

            entity.ClearUncommittedEvents();
        }
    }
}