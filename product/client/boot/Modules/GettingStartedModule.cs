using MoMoney.Presentation;
using momoney.presentation.model.eventing;
using momoney.presentation.presenters;
using MoMoney.Presentation.Presenters;
using MoMoney.Service.Infrastructure.Eventing;

namespace MoMoney.Modules
{
    public class GettingStartedModule :
        IModule,
        IEventSubscriber<NewProjectOpened>,
        IEventSubscriber<ClosingProjectEvent>
    {
        IRunPresenterCommand command;

        public GettingStartedModule(IRunPresenterCommand command)
        {
            this.command = command;
        }

        public void run()
        {
            command.run<GettingStartedPresenter>();
        }

        public void notify(NewProjectOpened message)
        {
            run();
        }

        public void notify(ClosingProjectEvent message)
        {
            run();
        }
    }
}