using gorilla.commons.utility;
using MoMoney.Domain.Core;

namespace MoMoney.Domain.Accounting
{
    class TotalPaymentsCalculator : ValueReturningVisitor<Money, Payment>
    {
        public TotalPaymentsCalculator()
        {
            reset();
        }

        public void visit(Payment payment)
        {
            value = value.add(payment.amount_paid);
        }

        public Money value { get; private set; }

        public void reset()
        {
            value = new Money(0);
        }
    }
}