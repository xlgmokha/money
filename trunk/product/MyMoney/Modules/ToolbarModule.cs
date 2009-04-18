using Gorilla.Commons.Infrastructure.Eventing;
using MoMoney.Modules.Core;
using MoMoney.Presentation.Model.Menu;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Presenters.Commands;
using MoMoney.Presentation.Presenters.Shell;

namespace MoMoney.Modules
{
    public interface IToolbarModule : IModule,
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
            broker.publish<IToolbarButton>(x => x.refresh());
        }

        public void notify(ClosingProjectEvent message)
        {
            broker.publish<IToolbarButton>(x => x.refresh());
        }

        public void notify(SavedChangesEvent message)
        {
            broker.publish<IToolbarButton>(x => x.refresh());
        }

        public void notify(UnsavedChangesEvent message)
        {
            broker.publish<IToolbarButton>(x => x.refresh());
        }
    }
}