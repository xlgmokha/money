using MoMoney.Infrastructure.eventing;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Presenters.Commands;

namespace MoMoney.Presentation.Presenters.Navigation
{
    public interface IMainMenuModule : IPresentationModule, IEventSubscriber<NewProjectOpened>
    {
    }

    public class MainMenuModule : IMainMenuModule
    {
        readonly IRunPresenterCommand command;
        readonly IEventAggregator broker;

        public MainMenuModule(IEventAggregator broker, IRunPresenterCommand command)
        {
            this.broker = broker;
            this.command = command;
        }

        public void run()
        {
            broker.subscribe_to(this);
        }

        public void notify(NewProjectOpened message)
        {
            command.run<IMainMenuPresenter>();
        }
    }
}