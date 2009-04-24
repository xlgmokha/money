using System;
using System.Collections.Generic;
using System.Linq;

namespace Gorilla.Commons.Utility.Extensions
{
    static public class ListExtensions
    {
        static public IListConstraint<T> add<T>(this IList<T> items, T item)
        {
            return new ListConstraint<T>(items, item);
        }

        static public IListConstraint<T> add_range<T>(this IList<T> items, IEnumerable<T> item)
        {
            return new ListConstraint<T>(items, item.ToArray());
        }
    }

    public class ListConstraint<T> : IListConstraint<T>
    {
        readonly IList<T> items;
        readonly T[] items_to_add;

        public ListConstraint(IList<T> list_to_constrain, params T[] items_to_add)
        {
            items = list_to_constrain;
            this.items_to_add = items_to_add;
            items_to_add.each(list_to_constrain.Add);
        }

        public void unless(Func<T, bool> predicate)
        {
            items_to_add.where(predicate).each(x => items.Remove(x));
        }
    }

    public interface IListConstraint<T>
    {
        void unless(Func<T, bool> predicate);
    }
}