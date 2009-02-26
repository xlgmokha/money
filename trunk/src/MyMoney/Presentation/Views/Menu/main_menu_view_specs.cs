using System.Windows.Forms;
using jpboodhoo.bdd.contexts;
using MyMoney.Presentation.Model.Menu;
using MyMoney.Presentation.Views.Menu.Mappers;
using MyMoney.Presentation.Views.Shell;
using MyMoney.Testing.spechelpers.contexts;
using MyMoney.Testing.spechelpers.core;

namespace MyMoney.Presentation.Views.Menu
{
    public class when_adding_sub_menus_to_the_main_menu_ : concerns_for<IMainMenuView>
    {
        it should_add_the_mapped_menu_strip_item_to_the_main_menu_strip =
            () => main_shell.was_told_to(x => x.add_to_main_menu(tool_strip_menu_item));

        context c = () =>
                        {
                            sub_menu = an<ISubMenu>();
                            mapper = an<ISubMenuToToolStripMenuItemMapper>();
                            main_shell = an<IShell>();
                            tool_strip_menu_item = new ToolStripMenuItem();
                            mapper.is_told_to(x => x.map_from(sub_menu)).it_will_return(tool_strip_menu_item);
                        };

        because b = () => sut.add(sub_menu);

        public override IMainMenuView create_sut()
        {
            return new main_menu_view(main_shell, mapper);
        }

        static ISubMenuToToolStripMenuItemMapper mapper;
        static IShell main_shell;
        static ISubMenu sub_menu;
        static ToolStripMenuItem tool_strip_menu_item;
    }
}