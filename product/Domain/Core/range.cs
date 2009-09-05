using System;

namespace MoMoney.Domain.Core
{
    public interface IRange<T> where T : IComparable
    {
        bool contains(T item);
        T start_of_range { get; }
        T end_of_range { get; }
    }

    public class Range<T> : IRange<T> where T : IComparable
    {
        public T start_of_range { get; private set; }
        public T end_of_range { get; private set; }

        public Range(T start_of_range, T end_of_range)
        {
            if (start_of_range.CompareTo(end_of_range) < 0)
            {
                this.start_of_range = start_of_range;
                this.end_of_range = end_of_range;
            }
            else
            {
                this.start_of_range = end_of_range;
                this.end_of_range = start_of_range;
            }
        }

        public bool contains(T item)
        {
            return start_of_range.CompareTo(item) <= 0 && end_of_range.CompareTo(item) >= 0;
        }
    }
}