using System;

namespace MoMoney.Domain.Core
{
    [Serializable]
    public class Money : IEquatable<Money>
    {
        double value;

        public static readonly Money Zero = new Money(0);

        public Money(double value)
        {
            this.value = value;
        }

        public Money add(Money other)
        {
            return new Money(value + other.value);
        }

        static public implicit operator Money(double value)
        {
            return new Money(value);
        }

        public bool Equals(Money other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.value.Equals(value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (!(obj is Money)) return false;
            return Equals((Money) obj);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        static public bool operator ==(Money left, Money right)
        {
            return Equals(left, right);
        }

        static public bool operator !=(Money left, Money right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return value.ToString("c");
        }
    }
}