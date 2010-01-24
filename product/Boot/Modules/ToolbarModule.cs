using momoney.presentation.model.eventing;
using MoMoney.Presentation.Model.Menu;
using momoney.presentation.presenters;
using MoMoney.Presentation.Presenters;
using MoMoney.Service.Infrastructure.Eventing;

namespace MoMoney.Modules
{
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
            command.run<ToolBarPresenter>();
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