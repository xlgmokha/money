using momoney.presentation.model.eventing;
using momoney.presentation.presenters;
using MoMoney.Presentation.Presenters;
using MoMoney.Service.Infrastructure.Eventing;

namespace MoMoney.Modules
{
    public class NavigationModule : INavigationModule
    {
        IEventAggregator broker;
        IRunPresenterCommand command;

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
            command.run<NavigationPresenter>();
        }
    }
}