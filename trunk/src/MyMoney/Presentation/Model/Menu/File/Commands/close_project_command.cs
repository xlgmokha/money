using MyMoney.Presentation.Model.Projects;
using MyMoney.Presentation.Views.Shell;
using MyMoney.Utility.Core;

namespace MyMoney.Presentation.Model.Menu.File.Commands
{
    public interface ICloseCommand : ICommand
    {
    }

    public class close_project_command : ICloseCommand
    {
        readonly IShell shell;
        readonly IProject project;

        public close_project_command(IShell shell, IProject project)
        {
            this.shell = shell;
            this.project = project;
        }

        public void run()
        {
            project.start_a_new_project();
            shell.close_all_windows();
        }
    }
}