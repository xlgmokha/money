using MoMoney.Presentation.Views.Shell;
using MoMoney.Utility.Core;

namespace MoMoney.Presentation.Model.Menu.File.Commands
{
    public interface ICloseWindowCommand : ICommand
    {}

    public class close_window_command : ICloseWindowCommand
    {
        private readonly IShell shell;

        public close_window_command(IShell shell)
        {
            this.shell = shell;
        }

        public void run()
        {
            shell.close_the_active_window();
        }
    }
}