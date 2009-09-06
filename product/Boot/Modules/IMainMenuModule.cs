using MoMoney.Presentation;
using MoMoney.Presentation.Model.messages;
using MoMoney.Service.Infrastructure.Eventing;

namespace MoMoney.Modules
{
    public interface IMainMenuModule : IModule, IEventSubscriber<NewProjectOpened>
    {
    }
}