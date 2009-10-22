using gorilla.commons.utility;
using MoMoney.Domain.Core;

namespace MoMoney.Domain.Accounting
{
    class TotalPaymentsCalculator : ValueReturningVisitor<Money, IPayment>
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