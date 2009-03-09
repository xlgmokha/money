using MoMoney.Infrastructure.Logging;
using MoMoney.Presentation.Model.Projects;
using MoMoney.Utility.Core;

namespace MoMoney.Presentation.Model.Menu.File.Commands
{
    public interface ICloseCommand : ICommand, ISaveChangesCallback, ILoggable
    {
    }

    public class CloseProjectCommand : ICloseCommand
    {
        readonly IProject project;
        readonly ISaveChangesCommand command;

        public CloseProjectCommand(IProject project, ISaveChangesCommand command)
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
            project.close();
        }

        public void not_saved()
        {
            project.close();
        }

        public void cancelled()
        {
        }
    }
}