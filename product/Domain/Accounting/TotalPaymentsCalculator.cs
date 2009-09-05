using Gorilla.Commons.Utility.Core;
using MoMoney.Domain.Core;

namespace MoMoney.Domain.Accounting
{
    internal class TotalPaymentsCalculator : IValueReturningVisitor<Money, IPayment>
    {
        public TotalPaymentsCalculator()
        {
            reset();
        }

        public void visit(IPayment payment)
        {
            value = payment.apply_to(value);
        }

        public Money value { get; private set; }

        public void reset()
        {
            value = new Money(0);
        }
    }
}