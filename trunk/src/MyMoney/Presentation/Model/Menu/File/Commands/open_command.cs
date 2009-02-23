using MyMoney.Presentation.Model.Projects;
using MyMoney.Presentation.Presenters.Commands;
using MyMoney.Presentation.Views.dialogs;
using MyMoney.Utility.Core;

namespace MyMoney.Presentation.Model.Menu.File.Commands
{
    public interface IOpenCommand : ICommand
    {
    }

    public class open_command : IOpenCommand
    {
        private readonly ISelectFileToOpenDialog view;
        private readonly IProject project;
        private readonly ILoadApplicationShellCommand command;

        public open_command(ISelectFileToOpenDialog view, IProject project, ILoadApplicationShellCommand command)
        {
            this.view = view;
            this.command = command;
            this.project = project;
        }

        public void run()
        {
            project.open(view.tell_me_the_path_to_the_file());
            command.run();
        }
    }
}