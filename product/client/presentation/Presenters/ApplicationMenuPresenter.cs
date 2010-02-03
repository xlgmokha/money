using System.Windows.Forms;
using gorilla.commons.utility;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Model.Menu;
using momoney.presentation.views;

namespace momoney.presentation.presenters
{
    public class ApplicationMenuPresenter : Presenter
    {
        ISubMenuRegistry registry;

        public ApplicationMenuPresenter(ISubMenuRegistry registry)
        {
            this.registry = registry;
        }

        public void present(Shell shell)
        {
            shell.region<MenuStrip>(x => registry.all().each(y => y.add_to(x)));
        }
    }
}
