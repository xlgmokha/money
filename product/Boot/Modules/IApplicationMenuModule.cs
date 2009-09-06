using MoMoney.Presentation;
using MoMoney.Presentation.Model.messages;
using MoMoney.Service.Infrastructure.Eventing;

namespace MoMoney.Modules
{
    public interface IApplicationMenuModule : IModule,
                                              IEventSubscriber<NewProjectOpened>,
                                              IEventSubscriber<ClosingProjectEvent>,
                                              IEventSubscriber<SavedChangesEvent>,
                                              IEventSubscriber<UnsavedChangesEvent>
    {
    }
}