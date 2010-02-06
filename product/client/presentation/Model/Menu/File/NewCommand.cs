using gorilla.commons.utility;
using MoMoney.Presentation.Model.Menu.File;
using MoMoney.Presentation.Model.Projects;

namespace momoney.presentation.model.menu.file
{
    public interface INewCommand : Command, ISaveChangesCallback
    {
    }

    public class NewCommand : INewCommand
    {
        readonly IProjectController current_project;
        readonly ISaveChangesCommand save_changes_command;

        public NewCommand(IProjectController current_project, ISaveChangesCommand save_changes_command)
        {
            this.current_project = current_project;
            this.save_changes_command = save_changes_command;
        }

        public void run()
        {
            save_changes_command.run_against(this);
        }

        public void saved()
        {
            current_project.start_new_project();
        }

        public void not_saved()
        {
            current_project.start_new_project();
        }

        public void cancelled()
        {
        }
    }
}