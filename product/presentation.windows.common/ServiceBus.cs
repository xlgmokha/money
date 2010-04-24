using System;

namespace presentation.windows.common
{
    public interface ServiceBus
    {
        void publish<T>() where T : new();
        void publish<T>(T item) where T : new();
        void publish<T>(Action<T> configure) where T : new();
    }
}