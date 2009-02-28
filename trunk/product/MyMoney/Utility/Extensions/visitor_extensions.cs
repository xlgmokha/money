using System.Collections.Generic;
using MyMoney.Utility.Core;

namespace MyMoney.Utility.Extensions
{
    public static class visitor_extensions
    {
        public static Result return_value_from_visiting_all_items_with<Result, T>(this IEnumerable<T> items,
                                                                                  IValueReturningVisitor<Result, T>
                                                                                      visitor)
        {
            visitor.reset();
            items.visit_all_items_with(visitor);
            return visitor.value;
        }

        public static void visit_all_items_with<T>(this IEnumerable<T> items, IVisitor<T> visitor)
        {
            foreach (var item in items) {
                visitor.visit(item);
            }
        }
    }
}