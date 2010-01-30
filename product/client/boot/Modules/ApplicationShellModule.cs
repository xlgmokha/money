using MoMoney.Presentation;
using momoney.presentation.presenters;
using MoMoney.Presentation.Presenters;

namespace MoMoney.Modules
{
    public class ApplicationShellModule : IModule
    {
        readonly IRunPresenterCommand command;

        public ApplicationShellModule(IRunPresenterCommand command)
        {
            this.command = command;
        }

        public void run()
        {
            command.run<ApplicationShellPresenter>();
        }
    }
}