using gorilla.commons.utility;
using Gorilla.Commons.Utility;
using MoMoney.Domain.Core;

namespace MoMoney.Domain.Accounting
{
    public class AnnualIncomeVisitor : ValueReturningVisitor<Money, IIncome>
    {
        readonly Year year;

        public AnnualIncomeVisitor(Year year)
        {
            this.year = year;
            reset();
        }

        public void visit(IIncome x)
        {
            if (x.date_of_issue.is_in(year)) value = value.add(x.amount_tendered);
        }

        public Money value { get; set; }

        public void reset()
        {
            value = new Money(0);
        }
    }
}