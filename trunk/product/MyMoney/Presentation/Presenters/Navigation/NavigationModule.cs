using MoMoney.Infrastructure.eventing;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Presenters.Commands;

namespace MoMoney.Presentation.Presenters.Navigation
{
    public interface INavigationModule : IPresentationModule, IEventSubscriber<new_project_opened>
    {
    }

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

        public void notify(new_project_opened message)
        {
            command.run<INavigationPresenter>();
        }
    }
}