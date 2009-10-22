using MoMoney.Presentation;
using momoney.presentation.presenters;
using MoMoney.Presentation.Presenters;

namespace MoMoney.Modules
{
    public interface IApplicationShellModule : IModule
    {
    }

    public class ApplicationShellModule : IApplicationShellModule
    {
        readonly IRunPresenterCommand command;

        public ApplicationShellModule(IRunPresenterCommand command)
        {
            this.command = command;
        }

        public void run()
        {
            command.run<IApplicationShellPresenter>();
        }
    }
}