using System.Collections.Generic;
using gorilla.commons.utility;

namespace presentation.windows.domain.payroll
{
    public class Grant
    {
        Date issued_on;
        IList<Unit> units_issued = new List<Unit>();

        static public Grant New(Money purchase_amount, UnitPrice price)
        {
            var grant = new Grant
                        {
                            issued_on = Calendar.now(),
                        };
            price.purchase_units(purchase_amount).each(x => grant.add(x));
            return grant;
        }

        public void change_unit_price_to(UnitPrice new_price)
        {
            units_issued.each(x => x.change_price(new_price));
        }

        public bool was_issued_on(Date date)
        {
            return issued_on.Equals(date);
        }

        public Money current_value()
        {
            var total = Money.Zero;
            units_issued.each(x => total = total.Plus(x.current_value()));
            return total;
        }

        void add(Unit unit)
        {
            units_issued.Add(unit);
        }

        public bool will_vest_in(int year)
        {
            return true;
        }

        public Money vesting_amount()
        {
            return current_value().divided_by(3);
        }
    }
}