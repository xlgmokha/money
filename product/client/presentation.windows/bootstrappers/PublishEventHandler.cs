using MoMoney.Service.Infrastructure.Eventing;
using presentation.windows.common;

namespace presentation.windows.bootstrappers
{
    public class PublishEventHandler<T> : AbstractHandler<T> where T : IEvent
    {
        EventAggregator event_aggregator;

        public PublishEventHandler(EventAggregator event_aggregator)
        {
            this.event_aggregator = event_aggregator;
        }

        public override void handle(T item)
        {
            event_aggregator.publish(item);
        }
    }
}