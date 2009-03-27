using MoMoney.Infrastructure.eventing;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Presenters.Commands;

namespace MoMoney.Presentation.Presenters.Shell
{
    public interface IToolbarModule : IPresentationModule,
                                      IEventSubscriber<NewProjectOpened>,
                                      IEventSubscriber<ClosingProjectEvent>,
                                      IEventSubscriber<SavedChangesEvent>,
                                      IEventSubscriber<UnsavedChangesEvent>

    {
    }

    public class ToolbarModule : IToolbarModule
    {
        readonly IEventAggregator broker;
        readonly IRunPresenterCommand command;

        public ToolbarModule(IEventAggregator broker, IRunPresenterCommand command)
        {
            this.broker = broker;
            this.command = command;
        }

        public void run()
        {
            broker.subscribe(this);
            command.run<IToolbarPresenter>();
        }

        public void notify(NewProjectOpened message)
        {
            command.run<IToolbarPresenter>();
        }

        public void notify(ClosingProjectEvent message)
        {
            command.run<IToolbarPresenter>();
        }

        public void notify(SavedChangesEvent message)
        {
            command.run<IToolbarPresenter>();
        }

        public void notify(UnsavedChangesEvent message)
        {
            command.run<IToolbarPresenter>();
        }
    }
}