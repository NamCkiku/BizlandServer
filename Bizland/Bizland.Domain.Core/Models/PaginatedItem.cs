﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bizland.Domain.Core.Models
{
    public class PaginatedItem<TResponse> : ValueObjectBase
    {
        public PaginatedItem(long totalItems, long totalPages, IReadOnlyList<TResponse> items)
        {
            TotalItems = totalItems;
            TotalPages = totalPages;
            Items = items;
        }

        public long TotalItems { get; }

        public long TotalPages { get; }

        public IReadOnlyList<TResponse> Items { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return TotalItems;
            yield return TotalPages;
            yield return Items;
        }
    }
}
