using MyMoney.Presentation.Model.Projects;
using MyMoney.Utility.Core;

namespace MyMoney.Presentation.Model.Menu.File.Commands
{
    public interface ISaveCommand : ICommand
    {}

    public class save_command : ISaveCommand
    {
        private readonly IProject the_current_project;
        private readonly ISaveAsCommand save_as_command;

        public save_command(IProject current_project, ISaveAsCommand save_as_command)
        {
            the_current_project = current_project;
            this.save_as_command = save_as_command;
        }

        public void run()
        {
            if (the_current_project.has_been_saved_at_least_once()) {
                the_current_project.save_changes();
            }
            else {
                save_as_command.run();
            }
        }
    }
}