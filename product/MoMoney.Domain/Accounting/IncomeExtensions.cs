using System.Collections.Generic;
using Gorilla.Commons.Utility;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.Domain.Core;

namespace MoMoney.Domain.Accounting
{
    static public class IncomeExtensions
    {
        static public Money in_the(this IEnumerable<IIncome> income_collected, Year year)
        {
            return income_collected.return_value_from_visiting_all_items_with(new AnnualIncomeVisitor(year));
        }
    }
}