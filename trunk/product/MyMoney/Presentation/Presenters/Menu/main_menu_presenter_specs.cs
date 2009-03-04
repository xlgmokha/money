using jpboodhoo.bdd.contexts;
using MyMoney.Presentation.Model.Menu;
using MyMoney.Presentation.Views.Menu;
using MyMoney.Testing.MetaData;
using MyMoney.Testing.spechelpers.contexts;
using MyMoney.Testing.spechelpers.core;

namespace MyMoney.Presentation.Presenters.Menu
{
    [Concern(typeof (main_menu_presenter))]
    public abstract class behaves_like_the_main_menu_presenter : concerns_for<IMainMenuPresenter, main_menu_presenter>
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