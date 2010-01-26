using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using gorilla.commons.utility;

namespace MoMoney.Service.Infrastructure.Eventing
{
    public class EventAggregator : IEventAggregator
    {
        readonly SynchronizationContext context;
        readonly HashSet<object> subscribers = new HashSet<object>();
        readonly object mutex = new object();

        public EventAggregator(SynchronizationContext context)
        {
            this.context = context;
        }

        public void subscribe_to<Event>(IEventSubscriber<Event> subscriber) where Event : IEvent
        {
            subscribe(subscriber);
        }

        public void subscribe<Listener>(Listener subscriber) 
        {
            within_lock(() => subscribers.Add(subscriber));
        }

        public void publish<Event>(Event the_event_to_broadcast) where Event : IEvent
        {
            var current_subscribers = subscribers.ToList();
            process(() => current_subscribers.call_on_each<IEventSubscriber<Event>>(x => x.notify(the_event_to_broadcast)));
        }

        public void publish<T>(Action<T> call) where T : class
        {
            var current_subscribers = subscribers.ToList();
            process(() => current_subscribers.each(x => x.call_on(call)));
        }

        public void publish<Event>() where Event : IEvent, new()
        {
            publish(new Event());
        }

        void within_lock(Action action)
        {
            lock (mutex) action();
        }

        void process(Action action)
        {
            context.Send(x => action(), new object());
        }
    }
}