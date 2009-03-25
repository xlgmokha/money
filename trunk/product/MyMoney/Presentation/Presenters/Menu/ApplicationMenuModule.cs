using MoMoney.Infrastructure.eventing;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Presenters.Commands;

namespace MoMoney.Presentation.Presenters.Menu
{
    public interface IApplicationMenuModule : IPresentationModule,
                                       IEventSubscriber<NewProjectOpened>,
                                       IEventSubscriber<ClosingProjectEvent>,
                                       IEventSubscriber<SavedChangesEvent>,
                                       IEventSubscriber<UnsavedChangesEvent>
    {
    }

    public class ApplicationMenuModule : IApplicationMenuModule
    {
        readonly IEventAggregator broker;
        readonly IRunPresenterCommand command;

        public ApplicationMenuModule(IEventAggregator broker, IRunPresenterCommand command)
        {
            this.broker = broker;
            this.command = command;
        }

        public void run()
        {
            broker.subscribe_to<NewProjectOpened>(this);
            broker.subscribe_to<ClosingProjectEvent>(this);
            broker.subscribe_to<SavedChangesEvent>(this);
            broker.subscribe_to<UnsavedChangesEvent>(this);
            command.run<IApplicationMenuPresenter>();
        }

        public void notify(NewProjectOpened message)
        {
            command.run<IApplicationMenuPresenter>();
        }

        public void notify(ClosingProjectEvent message)
        {
            command.run<IApplicationMenuPresenter>();
        }

        public void notify(SavedChangesEvent message)
        {
            command.run<IApplicationMenuPresenter>();
        }

        public void notify(UnsavedChangesEvent message)
        {
            command.run<IApplicationMenuPresenter>();
        }
    }
}