using MyMoney.Presentation.Core;
using MyMoney.Presentation.Model.Menu;
using MyMoney.Presentation.Views.Menu;
using MyMoney.Utility.Extensions;

namespace MyMoney.Presentation.Presenters.Menu
{
    public interface IMainMenuPresenter : IPresentationModule
    {
    }

    public class main_menu_presenter : IMainMenuPresenter
    {
        readonly IMainMenuView main_menu;
        readonly ISubMenuRegistry registry;

        public main_menu_presenter(IMainMenuView main_menu, ISubMenuRegistry registry)
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