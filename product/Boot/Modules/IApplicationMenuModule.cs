using Gorilla.Commons.Infrastructure.Eventing;
using MoMoney.Presentation;
using MoMoney.Presentation.Model.messages;

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