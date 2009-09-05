using Gorilla.Commons.Infrastructure.Eventing;
using MoMoney.Presentation;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Presenters.Commands;
using MoMoney.Presentation.Presenters.Navigation;

namespace MoMoney.Modules
{
    public interface INavigationModule : IModule, IEventSubscriber<NewProjectOpened>
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

        public void notify(NewProjectOpened message)
        {
            command.run<INavigationPresenter>();
        }
    }
}