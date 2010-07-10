using System.Collections.Generic;

namespace presentation.windows.server.domain.payroll
{
    public class Unit
    {
        UnitPrice current_price;
        IList<History> history = new List<History>();

        static public Unit New(UnitPrice price)
        {
            var unit = new Unit();
            unit.change_price(price);
            return unit;
        }

        public void change_price(UnitPrice new_price)
        {
            current_price = new_price ?? 0;
            history.Add(History.New(new_price));
        }

        public Money current_value()
        {
            return current_price.to_money();
        }
    }
}