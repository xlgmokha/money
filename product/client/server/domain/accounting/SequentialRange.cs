using System;
using gorilla.commons.utility;

namespace presentation.windows.server.domain.accounting
{
    public class SequentialRange<T> : Range<T> where T : IComparable<T>
    {
        readonly T start;
        readonly T end;

        public SequentialRange(T start, T end)
        {
            this.start = start;
            this.end = end;
        }

        public bool includes(T item)
        {
            return item.CompareTo(start) >= 0 && item.CompareTo(end) <= 0;
        }

        public override string ToString()
        {
            return "{0} to {1}".format(start, end);
        }
    }
}