using System.Collections.Generic;
using Gorilla.Commons.Utility;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.Domain.Core;

namespace MoMoney.Domain.Accounting.Growth
{
    static public class IncomeExtensions
    {
        static public Money in_the(this IEnumerable<IIncome> income_collected, Year year)
        {
            var income_for_year = new Money(0);
            income_collected.each(x => { if (x.date_of_issue.is_in(year)) income_for_year = income_for_year.add(x.amount_tendered); });
            return income_for_year;
        }
    }
}