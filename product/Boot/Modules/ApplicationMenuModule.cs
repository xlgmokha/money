using MoMoney.Presentation;
using momoney.presentation.model.eventing;
using MoMoney.Presentation.Model.Menu;
using momoney.presentation.presenters;
using MoMoney.Presentation.Presenters;
using MoMoney.Service.Infrastructure.Eventing;

namespace MoMoney.Modules
{
    public class ApplicationMenuModule :
        IModule,
        IEventSubscriber<NewProjectOpened>,
        IEventSubscriber<ClosingProjectEvent>,
        IEventSubscriber<SavedChangesEvent>,
        IEventSubscriber<UnsavedChangesEvent>
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
            command.run<ApplicationMenuPresenter>();
        }

        public void notify(NewProjectOpened message)
        {
            broker.publish<IMenuItem>(x => x.refresh());
        }

        public void notify(ClosingProjectEvent message)
        {
            broker.publish<IMenuItem>(x => x.refresh());
        }

        public void notify(SavedChangesEvent message)
        {
            broker.publish<IMenuItem>(x => x.refresh());
        }

        public void notify(UnsavedChangesEvent message)
        {
            broker.publish<IMenuItem>(x => x.refresh());
        }
    }
}