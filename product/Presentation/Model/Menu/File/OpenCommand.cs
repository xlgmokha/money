using gorilla.commons.utility;
using MoMoney.Presentation.Model.Menu.File;
using MoMoney.Presentation.Model.Projects;
using momoney.presentation.views;

namespace momoney.presentation.model.menu.file
{
    public interface IOpenCommand : Command, ISaveChangesCallback
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