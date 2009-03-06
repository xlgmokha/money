using MoMoney.Presentation.Core;
using MoMoney.Presentation.Model.Menu;
using MoMoney.Presentation.Views.Menu;
using MoMoney.Utility.Extensions;

namespace MoMoney.Presentation.Presenters.Menu
{
    public interface IMainMenuPresenter : IPresentationModule
    {
    }

    public class main_menu_presenter : IMainMenuPresenter
    {
        readonly IMenuView main_menu;
        readonly ISubMenuRegistry registry;

        public main_menu_presenter(IMenuView main_menu, ISubMenuRegistry registry)
        {
            this.main_menu = main_menu;
            this.registry = registry;
        }

        public void run()
        {
            registry.all().each(x => main_menu.add(x));
        }
    }
}