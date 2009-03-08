using jpboodhoo.bdd.contexts;
using MoMoney.Presentation.Model.Menu;
using MoMoney.Presentation.Views.Menu;
using MoMoney.Testing.MetaData;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.Presentation.Presenters.Menu
{
    [Concern(typeof (MainMenuPresenter))]
    public abstract class behaves_like_the_main_menu_presenter : concerns_for<IMainMenuPresenter, MainMenuPresenter>
    {
        context c = () =>
                        {
                            main_menu = the_dependency<IMenuView>();
                            repository = the_dependency<ISubMenuRegistry>();
                        };

        static protected ISubMenuRegistry repository;
        static protected IMenuView main_menu;
    }

    public class when_initializing_the_main_menu_presenter : behaves_like_the_main_menu_presenter
    {
        context c = () =>
                        {
                            file_menu = an<ISubMenu>();
                            when_the(repository).is_asked_for(x => x.all()).it_will_return(file_menu);
                        };

        because b = () => sut.run();

        it should_add_each_of_the_sub_menus_to_the_main_menu = () => main_menu.was_told_to(x => x.add(file_menu));

        static ISubMenu file_menu;
    }
}