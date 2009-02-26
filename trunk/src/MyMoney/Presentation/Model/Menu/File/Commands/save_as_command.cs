using MyMoney.Presentation.Model.Projects;
using MyMoney.Presentation.Views.dialogs;
using MyMoney.Utility.Core;

namespace MyMoney.Presentation.Model.Menu.File.Commands
{
    public interface ISaveAsCommand : ICommand
    {
    }

    public class save_as_command : ISaveAsCommand
    {
        readonly IProject current_project;
        readonly ISelectFileToSaveToDialog view;

        public save_as_command(ISelectFileToSaveToDialog view, IProject current_project)
        {
            this.view = view;
            this.current_project = current_project;
        }

        public void run()
        {
            current_project.save_to(view.tell_me_the_path_to_the_file());
        }
    }
}