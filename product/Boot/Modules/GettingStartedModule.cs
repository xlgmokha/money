using MoMoney.Presentation;
using momoney.presentation.model.eventing;
using momoney.presentation.presenters;
using MoMoney.Presentation.Presenters;
using MoMoney.Service.Infrastructure.Eventing;

namespace MoMoney.Modules
{
    public interface IGettingStartedModule : IModule,
                                             IEventSubscriber<NewProjectOpened>,
                                             IEventSubscriber<ClosingProjectEvent>
    {
    }

    public class GettingStartedModule : IGettingStartedModule
    {
        readonly IEventAggregator broker;
        readonly IRunPresenterCommand command;

        public GettingStartedModule(IEventAggregator broker, IRunPresenterCommand command)
        {
            this.broker = broker;
            this.command = command;
        }

        public void run()
        {
            broker.subscribe(this);
            command.run<GettingStartedPresenter>();
        }

        public void notify(NewProjectOpened message)
        {
            command.run<GettingStartedPresenter>();
        }

        public void notify(ClosingProjectEvent message)
        {
            command.run<GettingStartedPresenter>();
        }
    }
}