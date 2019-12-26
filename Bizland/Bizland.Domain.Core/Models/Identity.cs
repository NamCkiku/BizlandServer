using Bizland.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bizland.Domain.Core.Models
{
    /// <summary>
    ///     Supertype for all Identity types
    /// </summary>
    public interface IIdentity
    {
        Guid Id { get; }
    }

    /// <summary>
    ///     Supertype for all Identity types with generic Id
    /// </summary>
    public interface IIdentityWithId<TId>
    {
        TId Id { get; }
    }

    public abstract class IdentityBase : IdentityBase<Guid>, IEquatable<IdentityBase<Guid>>, IIdentityWithId<Guid>
    {
        public IdentityBase() : base(IdHelper.GenerateId())
        {
        }
    }

    public abstract class IdentityBase<TId> : IEquatable<IdentityBase<TId>>, IIdentityWithId<TId>
    {
        protected IdentityBase(TId id)
        {
            Id = id;
        }

        public bool Equals(IdentityBase<TId> id)
        {
            if (ReferenceEquals(this, id))
                return true;
            return !ReferenceEquals(null, id) && Id.Equals(id.Id);
        }

        public TId Id { get; protected set; }

        public override bool Equals(object anotherObject)
        {
            return Equals(anotherObject as IdentityBase<TId>);
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode() * 907 + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }
    }
}
