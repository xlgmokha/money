using MoMoney.Infrastructure.eventing;
using MoMoney.Modules.Core;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Presenters.Commands;
using MoMoney.Presentation.Presenters.Shell;

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
            broker.subscribe_to<NewProjectOpened>(this);
            broker.subscribe_to<ClosingProjectEvent>(this);
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