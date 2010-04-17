using gorilla.commons.utility;

namespace presentation.windows.service.infrastructure
{
    public interface ServiceBus
    {
        void run<T>(Command<T> command, T item);
    }
}