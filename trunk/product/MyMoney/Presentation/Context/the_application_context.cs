using System.Windows.Forms;
using MoMoney.Presentation.Model.Menu.File.Commands;
using MoMoney.Presentation.Presenters.Commands;
using MoMoney.Presentation.Views.Shell;
using MoMoney.Utility.Extensions;

namespace MoMoney.Presentation.Context
{
    public class the_application_context : ApplicationContext
    {
        public the_application_context(IShell shell_view,
                                       IExitCommand exit_command,
                                       ILoadPresentationModulesCommand command)
        {
            shell_view.downcast_to<Form>().Closed += ((sender, args) => exit_command.run());
            MainForm = shell_view.downcast_to<Form>();
            command.run();
        }
    }
}