using Bizland.Domain.Core.Models;
using Bizland.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bizland.Domain.Core
{
    public interface IEntity : IEntityWithId<Guid>
    {
    }

    /// <inheritdoc />
    /// <summary>
    ///  Supertype for all Entity types
    /// </summary>
    public interface IEntityWithId<TId> : IIdentityWithId<TId>
    {
    }

    public abstract class EntityBase : EntityWithIdBase<Guid>
    {
        protected EntityBase() : base(IdHelper.GenerateId())
        {
        }

        protected EntityBase(Guid id) : base(id)
        {
        }
    }

    public abstract class EntityWithIdBase<TId> : IEntityWithId<TId>
    {
        protected EntityWithIdBase(TId id)
        {
            Id = id;
            Created = DateTimeHelper.GenerateDateTime();
        }

        public DateTime Created { get; protected set; }

        public DateTime Updated { get; protected set; }

        [Key] public TId Id { get; protected set; }
    }
}
