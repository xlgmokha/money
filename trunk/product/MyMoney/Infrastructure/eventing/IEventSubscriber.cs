namespace MyMoney.Infrastructure.eventing
{
    public interface IEventSubscriber<Event> where Event : IEvent
    {
        void notify(Event message);
    }
}