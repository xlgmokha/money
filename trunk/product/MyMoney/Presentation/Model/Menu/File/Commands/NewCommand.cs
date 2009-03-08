using MoMoney.Presentation.Model.Projects;
using MoMoney.Utility.Core;

namespace MoMoney.Presentation.Model.Menu.File.Commands
{
    public interface INewCommand : ICommand, ISaveChangesCallback
    {
    }

    public class NewCommand : INewCommand
    {
        readonly IProject current_project;
        readonly ISaveChangesCommand save_changes_command;

        public NewCommand(IProject current_project, ISaveChangesCommand save_changes_command)
        {
            this.current_project = current_project;
            this.save_changes_command = save_changes_command;
        }

        public void run()
        {
            save_changes_command.run(this);
        }

        public void saved()
        {
            current_project.start_a_new_project();
        }

        public void not_saved()
        {
            current_project.start_a_new_project();
        }

        public void cancelled()
        {
        }
    }
}