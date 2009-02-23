using System.Windows.Forms;
using MyMoney.Presentation.Model.Menu;
using MyMoney.Presentation.Views.Menu.Mappers;
using MyMoney.Presentation.Views.Shell;
using MyMoney.Testing.Extensions;
using MyMoney.Testing.MetaData;

namespace MyMoney.Presentation.Views.Menu
{
    public class main_menu_view_specs
    {}

    public class when_adding_sub_menus_to_the_main_menu_ : old_context_specification<IMainMenuView>
    {
        [Observation]
        public void should_add_the_mapped_menu_strip_item_to_the_main_menu_strip()
        {
            main_shell.was_told_to(x => x.add_to_main_menu(tool_strip_menu_item));
        }

        protected override IMainMenuView context()
        {
            sub_menu = an<ISubMenu>();
            mapper = an<ISubMenuToToolStripMenuItemMapper>();
            main_shell = an<IShell>();
            tool_strip_menu_item = new ToolStripMenuItem();

            mapper.is_told_to(x => x.map_from(sub_menu)).Return(tool_strip_menu_item);

            return new main_menu_view(main_shell, mapper);
        }

        protected override void because()
        {
            sut.add(sub_menu);
        }

        private ISubMenuToToolStripMenuItemMapper mapper;
        private IShell main_shell;
        private ISubMenu sub_menu;
        private ToolStripMenuItem tool_strip_menu_item;
    }
}