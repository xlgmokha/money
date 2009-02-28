using MyMoney.Presentation.Views.Shell;
using MyMoney.Utility.Core;

namespace MyMoney.Presentation.Model.Menu.File.Commands
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