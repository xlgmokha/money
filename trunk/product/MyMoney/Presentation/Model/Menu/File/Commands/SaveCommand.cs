using MoMoney.Presentation.Model.Projects;
using MoMoney.Utility.Core;

namespace MoMoney.Presentation.Model.Menu.File.Commands
{
    public interface ISaveCommand : ICommand
    {
    }

    public class SaveCommand : ISaveCommand
    {
        readonly IProject the_current_project;
        readonly ISaveAsCommand save_as_command;

        public SaveCommand(IProject current_project, ISaveAsCommand save_as_command)
        {
            the_current_project = current_project;
            this.save_as_command = save_as_command;
        }

        public void run()
        {
            if (the_current_project.has_been_saved_at_least_once())
            {
                the_current_project.save_changes();
            }
            else
            {
                save_as_command.run();
            }
        }
    }
}