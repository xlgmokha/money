using MoMoney.Presentation;
using momoney.presentation.model.events;
using MoMoney.Service.Infrastructure.Eventing;

namespace MoMoney.Modules
{
    public interface INavigationModule : IModule, IEventSubscriber<NewProjectOpened>
    {
    }
}