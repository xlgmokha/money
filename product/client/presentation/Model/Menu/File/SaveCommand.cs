using gorilla.commons.utility;
using MoMoney.Presentation.Model.Projects;

namespace momoney.presentation.model.menu.file
{
    public interface ISaveCommand : Command {}

    public class SaveCommand : ISaveCommand
    {
        readonly IProjectController the_current_project;
        readonly ISaveAsCommand save_as_command;

        public SaveCommand(IProjectController current_project, ISaveAsCommand save_as_command)
        {
            the_current_project = current_project;
            this.save_as_command = save_as_command;
        }

        public void run()
        {
            if (the_current_project.has_been_saved_at_least_once()) the_current_project.save_changes();
            else save_as_command.run();
        }
    }
}