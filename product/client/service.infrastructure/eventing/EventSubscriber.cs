namespace MoMoney.Service.Infrastructure.Eventing
{
    public interface EventSubscriber<Event> where Event : IEvent
    {
        void notify(Event message);
    }
}