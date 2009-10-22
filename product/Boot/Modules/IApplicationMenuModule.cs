using MoMoney.Presentation;
using momoney.presentation.model.events;
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