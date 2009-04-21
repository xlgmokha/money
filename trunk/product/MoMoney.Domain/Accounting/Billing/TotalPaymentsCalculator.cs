using Gorilla.Commons.Utility.Core;
using MoMoney.Domain.Core;

namespace MoMoney.Domain.accounting.billing
{
    internal class TotalPaymentsCalculator : IValueReturningVisitor<IMoney, IPayment>
    {
        public TotalPaymentsCalculator()
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