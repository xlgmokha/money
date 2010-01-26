using System;

namespace MoMoney.Service.Infrastructure.Eventing
{
    public interface IEventAggregator
    {
        void subscribe_to<Event>(IEventSubscriber<Event> subscriber) where Event : IEvent;
        void subscribe<Listener>(Listener subscriber);
        void publish<Event>(Event the_event_to_broadcast) where Event : IEvent;
        void publish<T>(Action<T> call) where T : class;
        void publish<Event>() where Event : IEvent, new();
    }
}