﻿using Bizland.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bizland.Infrastructure.Infrastructure.EFCore
{
    public class QueryRepository<TEntity, TKey> : QueryRepository<DbContext, TEntity, TKey>
       where TEntity : class
    {
        public QueryRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }

    public class QueryRepository<TDbContext, TEntity, TKey> : IQueryRepository<TEntity, TKey>
        where TDbContext : DbContext
        where TEntity : class
    {
        private readonly TDbContext _dbContext;

        public QueryRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> Queryable()
        {
            return _dbContext.Set<TEntity>();
        }
    }
}
