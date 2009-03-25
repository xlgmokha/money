using MoMoney.Presentation.Model.Projects;
using MoMoney.Presentation.Views.dialogs;
using MoMoney.Utility.Core;

namespace MoMoney.Presentation.Model.Menu.File.Commands
{
    public interface ISaveAsCommand : ICommand
    {
    }

    public class SaveAsCommand : ISaveAsCommand
    {
        readonly IProject current_project;
        readonly ISelectFileToSaveToDialog view;

        public SaveAsCommand(ISelectFileToSaveToDialog view, IProject current_project)
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