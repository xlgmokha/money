using MyMoney.Domain.Core;

namespace MyMoney.Domain.accounting.billing
{
    public interface IPayment : IEntity
    {
        IMoney amount_paid { get; }
    }

    internal class payment : entity<IPayment>, IPayment
    {
        public payment(IMoney amount_paid)
        {
            this.amount_paid = amount_paid;
        }

        public IMoney amount_paid { get; private set; }

        public bool Equals(payment obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return base.Equals(obj) && Equals(obj.amount_paid, amount_paid);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as payment);
        }

        public override int GetHashCode()
        {
            unchecked {
                return (base.GetHashCode()*397) ^ (amount_paid != null ? amount_paid.GetHashCode() : 0);
            }
        }
    }
}