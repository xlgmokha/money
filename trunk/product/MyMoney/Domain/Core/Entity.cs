using System;
using MoMoney.Utility.Extensions;

namespace MoMoney.Domain.Core
{
    public interface IEntity
    {
        Guid id { get; }
    }

    [Serializable]
    public abstract class Entity<T> : IEntity where T : class, IEntity
    {
        protected Entity()
        {
            id = Guid.NewGuid();
            //UnitOfWork.For<T>().register(this as T);
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