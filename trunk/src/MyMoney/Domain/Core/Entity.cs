using System;
using MyMoney.Infrastructure.transactions;

namespace MyMoney.Domain.Core
{
    public interface IEntity
    {
        Guid Id { get; }
    }

    internal abstract class entity<T> : IEntity where T : class, IEntity
    {
        protected entity()
        {
            Id = Guid.NewGuid();
            UnitOfWork.start_for<T>().register(this as T);
        }

        public Guid Id { get; private set; }

        public bool Equals(entity<T> obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.Id.Equals(Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (entity<T>)) return false;
            return Equals((entity<T>) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}