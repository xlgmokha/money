using System;

namespace presentation.windows.server.domain.accounting
{
    public interface Range<T> where T : IComparable<T>
    {
        bool includes(T item);
    }
}