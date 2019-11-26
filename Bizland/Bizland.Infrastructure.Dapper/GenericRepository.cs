﻿using Bizland.Domain.Core;
using Bizland.Infrastructure.Dapper.DapperCRUD;
using Bizland.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizland.Infrastructure.Dapper
{
    public class GenericRepository<TEntity, TKey> : IRepositoryAsync<TEntity, TKey>, IQueryRepository<TEntity, TKey>
       where TEntity : DomainEntity<TKey>
    {
        public ISqlConnectionFactory SqlConnectionFactory { get; }

        public GenericRepository(ISqlConnectionFactory sqlConnectionFactory)
        {
            SqlConnectionFactory = sqlConnectionFactory;
        }

        public IQueryable<TEntity> Queryable()
        {
            using var conn = SqlConnectionFactory.GetOpenConnection();
            var entities = conn.GetList<TEntity>();
            return entities.AsQueryable();
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            using var conn = SqlConnectionFactory.GetOpenConnection();
            var entities = await conn.GetListAsync<TEntity>(new { id });
            return entities.FirstOrDefault();
        }

        public async Task<IReadOnlyCollection<TEntity>> GetByConditionAsync(object whereConditions)
        {
            using var conn = SqlConnectionFactory.GetOpenConnection();
            var entities = await conn.GetListAsync<TEntity>(whereConditions);
            return entities.ToList();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            using var conn = SqlConnectionFactory.GetOpenConnection();
            var newId = await conn.InsertAsync<TKey, TEntity>(entity);
            //if (entity is IAggregateRoot<TId> returnValue)
            //{
            //    returnValue.AsDynamic().Id = newId;
            //    return (TEntity)returnValue;
            //}

            //await DispatchEvents(entity);
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            using var conn = SqlConnectionFactory.GetOpenConnection();
            var numberRecordAffected = await conn.UpdateAsync(entity);
            if (numberRecordAffected <= 0)
            {
                throw new Exception("Could not update record to the database.");
            }

            //await DispatchEvents(entity);
            return await GetByIdAsync(entity.Id);
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            using var conn = SqlConnectionFactory.GetOpenConnection();
            var numberRecordAffected = await conn.DeleteAsync(entity);

            if (numberRecordAffected <= 0)
            {
                throw new Exception("Could not delete record in the database.");
            }

            //await DispatchEvents(entity);
            return numberRecordAffected;
        }

        //private async Task DispatchEvents(TEntity entity)
        //{
        //    foreach (var @event in entity.GetUncommittedEvents())
        //    {
        //        foreach (var eventBus in EventBuses)
        //        {
        //            await eventBus.Dispatch(@event);
        //        }
        //    }

        //    entity.ClearUncommittedEvents();
        //}
    }
}
