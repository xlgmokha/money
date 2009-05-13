namespace MoMoney.Service.Infrastructure.Security
{
    public class Role
    {
        readonly string name;

        public Role(string name)
        {
            this.name = name;
        }

        static public implicit operator string(Role role)
        {
            return role.name;
        }

        static public implicit operator Role(string role)
        {
            return new Role(role);
        }

        public bool Equals(Role other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.name, name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Role)) return false;
            return Equals((Role) obj);
        }

        public override int GetHashCode()
        {
            return (name != null ? name.GetHashCode() : 0);
        }
    }
}