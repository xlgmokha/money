using MoMoney.Presentation;
using momoney.presentation.model.eventing;
using momoney.presentation.presenters;
using MoMoney.Presentation.Presenters;
using MoMoney.Service.Infrastructure.Eventing;

namespace MoMoney.Modules
{
    public class NavigationModule : IModule, IEventSubscriber<NewProjectOpened>
    {
        IRunPresenterCommand command;

        public NavigationModule(IRunPresenterCommand command)
        {
            this.command = command;
        }

        public void run()
        {
        }

        public void notify(NewProjectOpened message)
        {
            command.run<NavigationPresenter>();
        }
    }
}