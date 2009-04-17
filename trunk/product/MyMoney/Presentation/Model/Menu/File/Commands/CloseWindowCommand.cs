using Gorilla.Commons.Utility.Core;
using MoMoney.Presentation.Views.Shell;

namespace MoMoney.Presentation.Model.Menu.File.Commands
{
    public interface ICloseWindowCommand : ICommand
    {
    }

    public class CloseWindowCommand : ICloseWindowCommand
    {
        readonly IShell shell;

        public CloseWindowCommand(IShell shell)
        {
            this.shell = shell;
        }

        public void run()
        {
            shell.close_the_active_window();
        }
    }
}