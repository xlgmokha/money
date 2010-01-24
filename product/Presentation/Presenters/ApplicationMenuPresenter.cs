using System.Windows.Forms;
using gorilla.commons.utility;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Model.Menu;
using momoney.presentation.views;

namespace momoney.presentation.presenters
{
    public interface IApplicationMenuPresenter : IPresenter {}

    public class ApplicationMenuPresenter : IApplicationMenuPresenter
    {
        readonly ISubMenuRegistry registry;
        readonly IRegionManager shell;

        public ApplicationMenuPresenter(ISubMenuRegistry registry, IRegionManager shell)
        {
            this.registry = registry;
            this.shell = shell;
        }

        public void present()
        {
            shell.region<MenuStrip>(x => registry.all().each(y => y.add_to(x)));
        }
    }
}