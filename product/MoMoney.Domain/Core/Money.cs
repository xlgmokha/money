using System;
using Gorilla.Commons.Utility.Extensions;

namespace MoMoney.Domain.Core
{
    [Serializable]
    public class Money : IEquatable<Money>
    {
        readonly long dollars;
        readonly int cents;

        public Money(long dollars) : this(dollars, 0)
        {
        }

        public Money(long dollars, int cents)
        {
            this.dollars = dollars;
            this.cents = cents;
            if (this.cents >= 100)
            {
                this.dollars += (this.cents/100).to_long();
                this.cents = this.cents%100;
            }
        }

        public Money add(Money other)
        {
            var new_dollars = dollars + other.dollars;
            if (other.cents + cents > 100)
            {
                ++new_dollars;
                var pennies = cents + other.cents - 100;
                return new Money(new_dollars, pennies);
            }
            return new Money(new_dollars, cents + other.cents);
        }

        public bool Equals(Money other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.dollars == dollars && other.cents == cents;
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
            unchecked
            {
                return (dollars.GetHashCode()*397) ^ cents;
            }
        }

        public static bool operator ==(Money left, Money right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Money left, Money right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return "{0}.{1:d2}".formatted_using(dollars, cents);
        }
    }
}