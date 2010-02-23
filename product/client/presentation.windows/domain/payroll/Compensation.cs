using System.Collections.Generic;
using System.Linq;
using gorilla.commons.utility;

namespace presentation.windows.domain.payroll
{
    public class Compensation
    {
        Money salary = Money.Zero;
        IList<Grant> grants = new List<Grant>();

        public void increase_salary_to(Money newSalary)
        {
            salary = newSalary;
        }

        public void issue_grant(Money grant_value, UnitPrice price)
        {
            grants.Add(Grant.New(grant_value, price));
        }

        public Grant grant_for(Date date)
        {
            return grants.Single(x => x.was_issued_on(date));
        }

        public Money how_much_will_they_take_home_in(int year)
        {
            var total = Money.Zero;
            grants
                .Where(x => x.will_vest_in(year))
                .each(x => total = total.Plus(x.vesting_amount()));
            return total.Plus(salary);
        }
    }
}