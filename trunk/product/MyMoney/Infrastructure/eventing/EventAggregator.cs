using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using MoMoney.Utility.Extensions;

namespace MoMoney.Infrastructure.eventing
{
    public interface IEventAggregator
    {
        void subscribe_to<Event>(IEventSubscriber<Event> subscriber) where Event : IEvent;
        void subscribe(object subscriber);
        void publish<Event>(Event the_event_to_broadcast) where Event : IEvent;
        void publish<Event>() where Event : IEvent, new();
    }

    public class EventAggregator : IEventAggregator
    {
        //readonly IDictionary<string, List<object>> subscribers;
        readonly SynchronizationContext context;
        readonly HashSet<object> listeners;
        readonly object mutex;

        public EventAggregator()
        {
            //subscribers = new Dictionary<string, List<object>>();
            listeners = new HashSet<object>();
            mutex = new object();
        }

        public void subscribe_to<Event>(IEventSubscriber<Event> subscriber) where Event : IEvent
        {
            subscribe(subscriber);
        }

        public void subscribe(object subscriber)
        {
            within_lock(() => listeners.Add(subscriber));
        }

        public void publish<Event>(Event the_event_to_broadcast) where Event : IEvent
        {
            //get_list_for<Event>()
            //    .Select(x => x.downcast_to<IEventSubscriber<Event>>())
            //    .each(x => x.notify(the_event_to_broadcast));

            listeners.call_on_each<IEventSubscriber<Event>>(x => x.notify(the_event_to_broadcast));
        }

        public void publish<Event>() where Event : IEvent, new()
        {
            publish(new Event());
        }

        //List<object> get_list_for<Event>()
        //{
        //    if (!subscribers.ContainsKey(typeof (Event).FullName))
        //    {
        //        subscribers.Add(typeof (Event).FullName, new List<object>());
        //    }
        //    return subscribers[typeof (Event).FullName];
        //}

        void within_lock(Action action)
        {
            lock (mutex)
            {
                action();
            }
        }
    }
}