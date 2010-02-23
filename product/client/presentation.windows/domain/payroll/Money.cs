using System;

namespace presentation.windows.domain.payroll
{
    public class Money : IEquatable<Money>
    {
        public double value { get; private set; }
        static public Money Zero = new Money(0);

        Money(double value)
        {
            this.value = value;
        }

        static public implicit operator Money(double raw)
        {
            return new Money(raw);
        }

        public Money Plus(Money otherMoney)
        {
            return value + otherMoney.value;
        }

        public bool Equals(Money other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.value == value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Money)) return false;
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

        public Money divided_by(int denominator)
        {
            return new Money(value/denominator);
        }
    }
}