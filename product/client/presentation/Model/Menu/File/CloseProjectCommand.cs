using Gorilla.Commons.Infrastructure.Logging;
using gorilla.commons.utility;
using MoMoney.Presentation.Model.Menu.File;
using MoMoney.Presentation.Model.Projects;

namespace momoney.presentation.model.menu.file
{
    public interface ICloseCommand : Command, ISaveChangesCallback, Loggable
    {
    }

    public class CloseProjectCommand : ICloseCommand
    {
        readonly IProjectController project;
        readonly ISaveChangesCommand command;

        public CloseProjectCommand(IProjectController project, ISaveChangesCommand command)
        {
            this.command = command;
            this.project = project;
        }

        public void run()
        {
            command.run(this);
        }

        public void saved()
        {
            project.close_project();
        }

        public void not_saved()
        {
            project.close_project();
        }

        public void cancelled()
        {
        }
    }
}