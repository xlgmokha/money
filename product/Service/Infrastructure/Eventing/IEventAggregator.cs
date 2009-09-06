using System;
using System.Linq.Expressions;

namespace MoMoney.Service.Infrastructure.Eventing
{
    public interface IEventAggregator
    {
        void subscribe_to<Event>(IEventSubscriber<Event> subscriber) where Event : IEvent;
        void subscribe<Listener>(Listener subscriber) where Listener : class;
        void publish<Event>(Event the_event_to_broadcast) where Event : IEvent;
        void publish<T>(Expression<Action<T>> call) where T : class;
        void publish<Event>() where Event : IEvent, new();
    }
}