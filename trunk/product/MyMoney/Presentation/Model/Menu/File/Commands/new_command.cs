using MoMoney.Presentation.Model.Projects;
using MoMoney.Presentation.Presenters.Commands;
using MoMoney.Utility.Core;

namespace MoMoney.Presentation.Model.Menu.File.Commands
{
    public interface INewCommand : ICommand, ISaveChangesCallback
    {
    }

    public class new_command : INewCommand
    {
        readonly IProject current_project;
        readonly ILoadApplicationShellCommand command;
        readonly ISaveChangesCommand save_changes_command;

        public new_command(IProject current_project, ILoadApplicationShellCommand command, ISaveChangesCommand save_changes_command)
        {
            this.current_project = current_project;
            this.save_changes_command = save_changes_command;
            this.command = command;
        }

        public void run()
        {
            save_changes_command.run(this);
        }

        public void saved()
        {
            current_project.start_a_new_project();
            command.run();
        }

        public void not_saved()
        {
            current_project.start_a_new_project();
            command.run();
        }

        public void cancelled()
        {
        }
    }
}