using MoMoney.Service.Application;

namespace MoMoney.Presentation.Model.interaction
{
    public interface INotification
    {
        void notify(params NotificationMessage[] messages);
    }
}