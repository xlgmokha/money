using MoMoney.Infrastructure.eventing;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Presenters.Commands;

namespace MoMoney.Presentation.Presenters.Shell
{
    public interface IGettingStartedModule : IPresentationModule, IEventSubscriber<NewProjectOpened>
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
            broker.subscribe_to(this);
            command.run<IGettingStartedPresenter>();
        }

        public void notify(NewProjectOpened message)
        {
            command.run<IGettingStartedPresenter>();
        }
    }
}