using System;
using gorilla.commons.utility;

namespace presentation.windows.server.domain
{
    public class Entity : IEquatable<Entity>
    {
        protected Entity()
        {
            id = Id<Guid>.Default;
        }

        public virtual Guid id { get; private set; }

        public virtual bool Equals(Entity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.id.Equals(id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (!(obj is Entity)) return false;
            return Equals((Entity) obj);
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        static public bool operator ==(Entity left, Entity right)
        {
            return Equals(left, right);
        }

        static public bool operator !=(Entity left, Entity right)
        {
            return !Equals(left, right);
        }
    }
}