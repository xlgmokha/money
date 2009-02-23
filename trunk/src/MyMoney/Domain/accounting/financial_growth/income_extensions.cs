using System.Collections.Generic;
using MyMoney.Domain.Core;

namespace MyMoney.Domain.accounting.financial_growth
{
    public static class income_extensions
    {
        public static IMoney in_the(this IEnumerable<IIncome> income_collected, IYear year)
        {
            IMoney income_for_year = new money(0);
            foreach (var income in income_collected) {
                if (income.date_of_issue.is_in(year)) {
                    income_for_year = income_for_year.add(income.amount_tendered);
                }
            }
            return income_for_year;
        }
    }
}