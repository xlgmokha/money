using System;
using MoMoney.Domain.Core;

namespace MoMoney.Domain.Accounting
{
    public interface IPayment : IEntity
    {
        Money apply_to(Money money);
    }

    [Serializable]
    internal class Payment : Entity<IPayment>, IPayment
    {
        Money amount_paid { get; set; }

        public Payment(Money amount_paid)
        {
            this.amount_paid = amount_paid;
        }

        public Money apply_to(Money money)
        {
            return money.add(amount_paid);
        }

        public bool Equals(Payment obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return base.Equals(obj) && Equals(obj.amount_paid, amount_paid);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as Payment);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (amount_paid != null ? amount_paid.GetHashCode() : 0);
            }
        }
    }
}