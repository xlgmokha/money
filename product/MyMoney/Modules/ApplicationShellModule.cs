using MoMoney.Presentation;
using MoMoney.Presentation.Presenters.Commands;
using MoMoney.Presentation.Presenters.Shell;

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