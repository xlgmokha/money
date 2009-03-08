using MoMoney.Presentation.Model.Projects;
using MoMoney.Presentation.Views.Shell;
using MoMoney.Utility.Core;

namespace MoMoney.Presentation.Model.Menu.File.Commands
{
    public interface ICloseCommand : ICommand, ISaveChangesCallback
    {
    }

    public class CloseProjectCommand : ICloseCommand
    {
        readonly IShell shell;
        readonly IProject project;
        readonly ISaveChangesCommand command;

        public CloseProjectCommand(IShell shell, IProject project, ISaveChangesCommand command)
        {
            this.shell = shell;
            this.command = command;
            this.project = project;
        }

        public void run()
        {
            command.run(this);
        }

        public void saved()
        {
            project.close();
            shell.close_all_windows();
        }

        public void not_saved()
        {
            project.close();
            shell.close_all_windows();
        }

        public void cancelled()
        {
        }
    }
}