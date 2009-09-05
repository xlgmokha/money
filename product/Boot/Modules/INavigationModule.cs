using Gorilla.Commons.Infrastructure.Eventing;
using MoMoney.Presentation;
using MoMoney.Presentation.Model.messages;

namespace MoMoney.Modules
{
    public interface INavigationModule : IModule, IEventSubscriber<NewProjectOpened>
    {
    }
}