using System;
using Gorilla.Commons.Utility.Core;
using Gorilla.Commons.Utility.Extensions;

namespace MoMoney.Domain.Core
{
    public interface IEntity : IIdentifiable<Guid>
    {
    }

    [Serializable]
    public abstract class Entity<T> : IEntity where T : class, IEntity
    {
        protected Entity()
        {
            id = Guid.NewGuid();
        }

        public Guid id { get; private set; }

        public bool Equals(Entity<T> obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.id.Equals(id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Entity<T>)) return false;
            return Equals((Entity<T>) obj);
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public override string ToString()
        {
            return "{0} id: {1}".formatted_using(base.ToString(), id);
        }
    }
}