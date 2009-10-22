using gorilla.commons.utility;
using MoMoney.Presentation.Model.Projects;
using momoney.presentation.views;

namespace momoney.presentation.model.menu.file
{
    public interface ISaveAsCommand : Command {}

    public class SaveAsCommand : ISaveAsCommand
    {
        readonly IProjectController current_project;
        readonly ISelectFileToSaveToDialog view;

        public SaveAsCommand(ISelectFileToSaveToDialog view, IProjectController current_project)
        {
            this.view = view;
            this.current_project = current_project;
        }

        public void run()
        {
            current_project.save_project_to(view.tell_me_the_path_to_the_file());
        }
    }
}