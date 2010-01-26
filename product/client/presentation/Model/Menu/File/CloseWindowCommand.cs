using gorilla.commons.utility;
using MoMoney.Presentation.Views;

namespace momoney.presentation.model.menu.file
{
    public interface ICloseWindowCommand : Command {}

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