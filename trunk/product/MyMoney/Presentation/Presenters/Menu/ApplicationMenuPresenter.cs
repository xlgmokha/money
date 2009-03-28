using System.Windows.Forms;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Model.Menu;
using MoMoney.Presentation.Views.Shell;
using MoMoney.Utility.Extensions;

namespace MoMoney.Presentation.Presenters.Menu
{
    public interface IApplicationMenuPresenter : IPresenter
    {
    }

    public class ApplicationMenuPresenter : IApplicationMenuPresenter
    {
        readonly ISubMenuRegistry registry;
        readonly IShell shell;

        public ApplicationMenuPresenter(ISubMenuRegistry registry, IShell shell)
        {
            this.registry = registry;
            this.shell = shell;
        }

        public void run()
        {
            shell.region<MenuStrip>(x => registry.all().each(y => y.add_to(x)));
        }
    }
}