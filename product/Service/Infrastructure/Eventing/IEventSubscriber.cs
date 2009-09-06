namespace MoMoney.Service.Infrastructure.Eventing
{
    public interface IEventSubscriber<Event> where Event : IEvent
    {
        void notify(Event message);
    }
}