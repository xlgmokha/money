using Gorilla.Commons.Utility.Extensions;

namespace MoMoney.Domain.Core
{
    public static class MoneyExtensions
    {
        public static Money as_money(this double amount)
        {
            var quotient = amount/0.01;
            var wholePart = (int) quotient;
            var mantissa = ((decimal) quotient) - wholePart;

            var roundedAmount = mantissa >= .5m ? .01*(wholePart + 1) : .01*wholePart;
            var cents = (roundedAmount*100).to_int();

            return new Money(cents/100, cents%100);
        }

        public static Money as_money(this int amount)
        {
            var quotient = amount/0.01;
            var wholePart = (int) quotient;
            var mantissa = ((decimal) quotient) - wholePart;

            var roundedAmount = mantissa >= .5m ? .01*(wholePart + 1) : .01*wholePart;
            var cents = (roundedAmount*100).to_int();

            return new Money(cents/100, cents%100);
        }
    }
}