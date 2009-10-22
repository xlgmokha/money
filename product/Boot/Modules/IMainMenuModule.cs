using MoMoney.Presentation;
using momoney.presentation.model.events;
using MoMoney.Service.Infrastructure.Eventing;

namespace MoMoney.Modules
{
    public interface IMainMenuModule : IModule, IEventSubscriber<NewProjectOpened>
    {
    }
}