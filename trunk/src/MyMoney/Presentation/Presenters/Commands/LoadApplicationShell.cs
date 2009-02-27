using MyMoney.Presentation.Core;
using MyMoney.Presentation.Views.Shell;
using MyMoney.Utility.Core;
using MyMoney.Utility.Extensions;

namespace MyMoney.Presentation.Presenters.Commands
{
    public interface ILoadApplicationShellCommand : ICommand
    {
    }

    public class LoadApplicationShell : ILoadApplicationShellCommand
    {
        readonly IShell shell;
        readonly IPresenterRegistry registry;
        readonly IApplicationController controller;

        public LoadApplicationShell(IPresenterRegistry registry, IApplicationController controller, IShell shell)
        {
            this.registry = registry;
            this.shell = shell;
            this.controller = controller;
        }

        public void run()
        {
            shell.clear_menu_items();
            shell.close_all_windows();
            registry.all_implementations_of<IPresentationModule>().each(x => controller.run(x));
        }
    }
}