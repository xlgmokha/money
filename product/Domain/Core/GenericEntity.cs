using System;
using gorilla.commons.utility;

namespace MoMoney.Domain.Core
{
    [Serializable]
    public abstract class GenericEntity<T> : Entity where T : class, Entity
    {
        protected GenericEntity()
        {
            id = Guid.NewGuid();
        }

        public Id<Guid> id { get; private set; }

        public bool Equals(GenericEntity<T> obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.id.Equals(id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (GenericEntity<T>)) return false;
            return Equals((GenericEntity<T>) obj);
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