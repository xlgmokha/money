using MoMoney.Presentation;
using momoney.presentation.model.eventing;
using MoMoney.Presentation.Model.Menu;
using momoney.presentation.presenters;
using MoMoney.Presentation.Presenters;
using MoMoney.Service.Infrastructure.Eventing;

namespace MoMoney.Modules
{
    public class ToolbarModule :
        IModule,
        EventSubscriber<NewProjectOpened>,
        EventSubscriber<ClosingProjectEvent>,
        EventSubscriber<SavedChangesEvent>,
        EventSubscriber<UnsavedChangesEvent>
    {
        readonly EventAggregator broker;
        readonly IRunPresenterCommand command;

        public ToolbarModule(EventAggregator broker, IRunPresenterCommand command)
        {
            this.broker = broker;
            this.command = command;
        }

        public void run()
        {
            command.run<ToolBarPresenter>();
        }

        public void notify(NewProjectOpened message)
        {
            refresh_toolbar();
        }

        void refresh_toolbar()
        {
            broker.publish<IToolbarButton>(x => x.refresh());
        }

        public void notify(ClosingProjectEvent message)
        {
            refresh_toolbar();
        }

        public void notify(SavedChangesEvent message)
        {
            refresh_toolbar();
        }

        public void notify(UnsavedChangesEvent message)
        {
            refresh_toolbar();
        }
    }
}