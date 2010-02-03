using gorilla.commons.utility;
using momoney.presentation.views;

namespace momoney.presentation.model.menu.file
{
    public interface ICloseWindowCommand : Command {}

    public class CloseWindowCommand : ICloseWindowCommand
    {
        readonly Shell shell;

        public CloseWindowCommand(Shell shell)
        {
            this.shell = shell;
        }

        public void run()
        {
            shell.close_the_active_window();
        }
    }
}