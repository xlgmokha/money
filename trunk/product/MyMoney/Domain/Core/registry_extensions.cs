using System.Collections.Generic;
using MoMoney.Utility.Extensions;

namespace MoMoney.Domain.Core
{
    public static class registry_extensions
    {
        public static IEnumerable<T> sort_all_using<T>(this IRegistry<T> registry, IComparer<T> comparer)
        {
            return registry.all().sorted_using(comparer);
        }
    }
}