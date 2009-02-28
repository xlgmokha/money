using MyMoney.Domain.Core;
using MyMoney.Utility.Core;

namespace MyMoney.Domain.accounting.billing
{
    internal class total_payments_calculator : IValueReturningVisitor<IMoney, IPayment>
    {
        public total_payments_calculator()
        {
            reset();
        }

        public void visit(IPayment payment)
        {
            value = value.add(payment.amount_paid);
        }

        public IMoney value { get; private set; }

        public void reset()
        {
            value = new Money(0);
        }
    }
}