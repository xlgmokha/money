using MoMoney.Presentation.Model.Projects;
using MoMoney.Presentation.Views.dialogs;
using MoMoney.Utility.Core;

namespace MoMoney.Presentation.Model.Menu.File.Commands
{
    public interface IOpenCommand : ICommand, ISaveChangesCallback
    {
    }

    public class OpenCommand : IOpenCommand
    {
        readonly ISelectFileToOpenDialog view;
        readonly IProjectController project;
        readonly ISaveChangesCommand save_changes_command;

        public OpenCommand(ISelectFileToOpenDialog view, IProjectController project, ISaveChangesCommand save_changes_command)
        {
            this.view = view;
            this.save_changes_command = save_changes_command;
            this.project = project;
        }

        public void run()
        {
            save_changes_command.run(this);
        }

        public void saved()
        {
            open_project();
        }

        public void not_saved()
        {
            open_project();
        }

        public void cancelled()
        {
        }

        void open_project()
        {
            project.open_project_from(view.tell_me_the_path_to_the_file());
        }
    }
}