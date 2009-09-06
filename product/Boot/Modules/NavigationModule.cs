using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Presenters;
using MoMoney.Presentation.Presenters.Navigation;
using MoMoney.Service.Infrastructure.Eventing;

namespace MoMoney.Modules
{
    public class NavigationModule : INavigationModule
    {
        readonly IEventAggregator broker;
        readonly IRunPresenterCommand command;

        public NavigationModule(IEventAggregator broker, IRunPresenterCommand command)
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
            command.run<INavigationPresenter>();
        }
    }
}