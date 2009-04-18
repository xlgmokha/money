using Gorilla.Commons.Utility.Core;
using MoMoney.Infrastructure.Logging;
using MoMoney.Presentation.Model.Projects;

namespace MoMoney.Presentation.Model.Menu.File.Commands
{
    public interface ICloseCommand : ICommand, ISaveChangesCallback, ILoggable
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