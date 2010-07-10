using System;
using System.Collections.Generic;

namespace tests
{
    static class Iterating
    {
        static public void each<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items) action(item);
        }
    }
}