using presentation.windows.common;

namespace presentation.windows.eventing
{
    public interface EventSubscriber<Event> where Event : IEvent
    {
        void notify(Event message);
    }
}