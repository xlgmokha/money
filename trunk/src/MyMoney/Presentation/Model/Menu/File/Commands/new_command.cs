using MyMoney.Presentation.Model.Projects;
using MyMoney.Presentation.Presenters.Commands;
using MyMoney.Utility.Core;

namespace MyMoney.Presentation.Model.Menu.File.Commands
{
    public interface INewCommand : ICommand
    {
    }

    public class new_command : INewCommand
    {
        readonly IProject current_project;
        readonly ILoadApplicationShellCommand command;

        public new_command(IProject current_project, ILoadApplicationShellCommand command)
        {
            this.current_project = current_project;
            this.command = command;
        }

        public void run()
        {
            current_project.start_a_new_project();
            command.run();
        }
    }
}