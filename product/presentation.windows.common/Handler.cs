using System;

namespace presentation.windows.common
{
    public interface Handler
    {
        bool can_handle(Type type);
        void handle(object item);
    }

    public interface Handler<T>
    {
        void handle(T item);
    }
}