using Gorilla.Commons.Utility.Core;
using MoMoney.Presentation.Model.Projects;
using MoMoney.Presentation.Views.dialogs;

namespace MoMoney.Presentation.Model.Menu.File.Commands
{
    public interface ISaveAsCommand : ICommand
    {
    }

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