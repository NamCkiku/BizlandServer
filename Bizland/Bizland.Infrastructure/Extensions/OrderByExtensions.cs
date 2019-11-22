﻿using Bizland.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Bizland.Infrastructure.Extensions
{
    public static class OrderByExtensions
    {
        public static IQueryable<TEntity> OrderByPropertyName<TEntity, TKey>(
            this IQueryable<TEntity> source,
            string propertyName,
            bool isDescending) where TEntity : DomainEntity<TKey>
        {
            if (source == null)
                throw new ArgumentException("source");

            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("propertyName");

            var type = typeof(TEntity);
            var arg = Expression.Parameter(type, "x");
            var propertyInfo = type.GetProperty(propertyName);
            Expression expression = Expression.Property(arg, propertyInfo);
            type = propertyInfo.PropertyType;

            var delegateType = typeof(Func<,>).MakeGenericType(typeof(TEntity), type);
            var lambda = Expression.Lambda(delegateType, expression, arg);

            var methodName = isDescending ? "OrderByDescending" : "OrderBy";
            var result = typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                              && method.IsGenericMethodDefinition
                              && method.GetGenericArguments().Length == 2
                              && method.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(TEntity), type)
                .Invoke(null, new object[] { source, lambda });

            return (IQueryable<TEntity>)result;
        }
    }
}
