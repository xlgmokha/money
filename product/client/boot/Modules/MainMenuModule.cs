using MoMoney.Presentation;
using momoney.presentation.model.eventing;
using MoMoney.Presentation.Presenters;
using MoMoney.Service.Infrastructure.Eventing;

namespace MoMoney.Modules
{
    public class MainMenuModule : IModule, IEventSubscriber<NewProjectOpened>
    {
        readonly IRunPresenterCommand command;

        public MainMenuModule(IRunPresenterCommand command)
        {
            this.command = command;
        }

        public void run()
        {
        }

        public void notify(NewProjectOpened message)
        {
            command.run<MainMenuPresenter>();
        }
    }
}