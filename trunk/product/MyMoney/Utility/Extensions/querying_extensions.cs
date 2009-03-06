using System;
using System.Collections.Generic;
using System.Linq;

namespace MoMoney.Utility.Extensions
{
    public static class querying_extensions
    {
        public static IEnumerable<T> where<T>(this IEnumerable<T> items, Func<T, bool> condition_is_met)
        {
            return items.Where(condition_is_met);
        }
    }
}