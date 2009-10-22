using System.Collections.Generic;
using Gorilla.Commons.Utility;
using MoMoney.Domain.Core;
using gorilla.commons.utility;

namespace MoMoney.Domain.Accounting
{
    static public class IncomeExtensions
    {
        static public Money in_the(this IEnumerable<IIncome> income_collected, Year year)
        {
            return income_collected.return_value_from_visiting_all_with(new AnnualIncomeVisitor(year));
        }
    }
}