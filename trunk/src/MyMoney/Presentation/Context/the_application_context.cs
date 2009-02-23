using System.Windows.Forms;
using MyMoney.Presentation.Model.Menu.File.Commands;
using MyMoney.Presentation.Presenters.Commands;
using MyMoney.Presentation.Views.Shell;
using MyMoney.Utility.Extensions;

namespace MyMoney.Presentation.Context
{
    public class the_application_context : ApplicationContext
    {
        public the_application_context(IShell shell_view,
                                       IExitCommand exit_command,
                                       ILoadApplicationShellCommand command)
        {
            shell_view.downcast_to<Form>().Closed += delegate { exit_command.run(); };
            MainForm = shell_view.downcast_to<Form>();
            command.run();
        }
    }
}