using System.Collections.Generic;
using System.Linq;
using Castle.Core;
using MoMoney.Infrastructure.Extensions;
using MoMoney.Utility.Extensions;

namespace MoMoney.Infrastructure.eventing
{
    public interface IEventAggregator
    {
        void subscribe_to<Event>(IEventSubscriber<Event> subscriber) where Event : IEvent;
        void publish<Event>(Event the_event_to_broadcast) where Event : IEvent;
        void publish<Event>() where Event : IEvent, new();
    }

    [Singleton]
    public class EventAggregator : IEventAggregator
    {
        readonly IDictionary<string, HashSet<object>> subscribers;

        public EventAggregator()
        {
            subscribers = new Dictionary<string, HashSet<object>>();
        }

        public void subscribe_to<Event>(IEventSubscriber<Event> subscriber) where Event : IEvent
        {
            if (!get_list_for<Event>().Contains(subscriber))
            {
                get_list_for<Event>().Add(subscriber);
            }
        }

        public void publish<Event>(Event the_event_to_broadcast) where Event : IEvent
        {
            get_list_for<Event>()
                .Select(x => x.downcast_to<IEventSubscriber<Event>>())
                .each(x =>
                          {
                              this.log().debug("publishing event {0} to {1}", typeof (Event).Name, x.GetType().FullName);
                              x.notify(the_event_to_broadcast);
                          }
                );
        }

        public void publish<Event>() where Event : IEvent, new()
        {
            publish(new Event());
        }

        HashSet<object> get_list_for<Event>()
        {
            if (!subscribers.ContainsKey(typeof (Event).FullName))
            {
                subscribers.Add(typeof (Event).FullName, new HashSet<object>());
            }
            return subscribers[typeof (Event).FullName];
        }
    }
}