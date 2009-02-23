namespace MyMoney.Presentation.Model.interaction
{
    public interface INotification
    {
        void notify(params notification_message[] messages);
    }
}