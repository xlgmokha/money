using System;
using MoMoney.Domain.Core;

namespace MoMoney.Domain.Accounting
{
    [Serializable]
    class Payment : GenericEntity<Payment>
    {
        static public Payment New(Money amount)
        {
            return new Payment
                   {
                       amount_paid = amount
                   };
        }

        public Money amount_paid { get; set; }

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