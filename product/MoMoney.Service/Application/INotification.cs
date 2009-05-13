namespace MoMoney.Service.Application
{
    public interface INotification
    {
        void notify(params NotificationMessage[] messages);
    }
}