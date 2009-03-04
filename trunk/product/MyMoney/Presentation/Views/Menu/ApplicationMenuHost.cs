using MyMoney.Presentation.Model.Menu;
using MyMoney.Presentation.Views.Menu.Mappers;
using MyMoney.Presentation.Views.Shell;

namespace MyMoney.Presentation.Views.Menu
{
    public interface IMenuView
    {
        void add(ISubMenu menu_to_add);
    }

    public class ApplicationMenuHost : IMenuView
    {
        private readonly ISubMenuToToolStripMenuItemMapper mapper;
        private readonly IShell application_shell;

        public ApplicationMenuHost(IShell application_shell, ISubMenuToToolStripMenuItemMapper mapper)
        {
            this.mapper = mapper;
            this.application_shell = application_shell;
        }

        public void add(ISubMenu menu_to_add)
        {
            application_shell.add_to_main_menu(mapper.map_from(menu_to_add));
        }
    }
}