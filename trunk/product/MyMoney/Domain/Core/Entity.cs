using System;
using MyMoney.Infrastructure.transactions;

namespace MyMoney.Domain.Core
{
    public interface IEntity
    {
        Guid Id { get; }
    }

    [Serializable]
    public abstract class Entity<T> : IEntity where T : class, IEntity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
            UnitOfWork.For<T>().register(this as T);
        }

        public Guid Id { get; private set; }

        public bool Equals(Entity<T> obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.Id.Equals(Id);
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
            return Id.GetHashCode();
        }
    }
}