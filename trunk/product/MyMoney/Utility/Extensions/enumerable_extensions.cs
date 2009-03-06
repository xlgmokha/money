using System;
using System.Collections.Generic;
using System.Linq;

namespace MoMoney.Utility.Extensions
{
    public static class enumerable_extensions
    {
        public static IList<T> databind<T>(this IEnumerable<T> items_to_bind_to)
        {
            return items_to_bind_to.ToList();
        }

        public static IEnumerable<T> that_satisfy<T>(this IEnumerable<T> items_to_peek_in_to,
                                                     Predicate<T> criteriaToSatisfy)
        {
            foreach (var item in items_to_peek_in_to ?? new List<T>())
            {
                if (item.satisfies(criteriaToSatisfy))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> sorted_using<T>(this IEnumerable<T> itemsToSort, IComparer<T> sortingAlgorithm)
        {
            var sorted_items = new List<T>(itemsToSort);
            sorted_items.Sort(sortingAlgorithm);
            return sorted_items;
        }

        public static IEnumerable<T> all<T>(this IEnumerable<T> items)
        {
            foreach (var item in items ?? new List<T>()) yield return item;
        }

        public static void each<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items ?? new List<T>()) action(item);
        }
    }
}