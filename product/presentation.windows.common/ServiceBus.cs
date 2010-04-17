using System;

namespace presentation.windows.common
{
    public interface ServiceBus
    {
        void publish<T>();
        void publish<T>(T item);
        void publish<T>(Action<T> configure);
    }
}