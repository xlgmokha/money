using System.Collections.Generic;

namespace presentation.windows.domain.payroll
{
    public class UnitPrice
    {
        double price;

        UnitPrice(double price)
        {
            this.price = price;
        }

        static public implicit operator UnitPrice(double raw)
        {
            return new UnitPrice(raw);
        }

        public IEnumerable<Unit> purchase_units(Money amount)
        {
            for (var i = 0; i < number_of_units(amount); i++) yield return Unit.New(this);
        }

        double number_of_units(Money amount)
        {
            return amount.value/price;
        }

        public Money to_money()
        {
            return price;
        }
    }
}