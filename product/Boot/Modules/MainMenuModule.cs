using momoney.presentation.model.eventing;
using MoMoney.Presentation.Presenters;
using MoMoney.Service.Infrastructure.Eventing;

namespace MoMoney.Modules
{
    public class MainMenuModule : IMainMenuModule
    {
        readonly IEventAggregator broker;
        readonly IRunPresenterCommand command;

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