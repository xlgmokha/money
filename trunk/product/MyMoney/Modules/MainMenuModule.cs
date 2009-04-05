using MoMoney.Infrastructure.eventing;
using MoMoney.Modules.Core;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Presenters.Commands;
using MoMoney.Presentation.Presenters.Navigation;

namespace MoMoney.Modules
{
    public interface IMainMenuModule : IModule, IEventSubscriber<NewProjectOpened>
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