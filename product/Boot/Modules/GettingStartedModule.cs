using MoMoney.Presentation;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Presenters;
using MoMoney.Presentation.Presenters.Shell;
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
            command.run<IGettingStartedPresenter>();
        }

        public void notify(NewProjectOpened message)
        {
            command.run<IGettingStartedPresenter>();
        }

        public void notify(ClosingProjectEvent message)
        {
            command.run<IGettingStartedPresenter>();
        }
    }
}