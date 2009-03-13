using System.Windows.Forms;
using MoMoney.Presentation.Model.Menu;
using MoMoney.Presentation.Views.Menu.Mappers;
using MoMoney.Presentation.Views.Shell;

namespace MoMoney.Presentation.Views.Menu
{
    public interface IMenuView
    {
        void add(ISubMenu menu_to_add);
    }

    public class ApplicationMenuHost : IMenuView
    {
        readonly ISubMenuToToolStripMenuItemMapper mapper;
        readonly IShell shell;

        public ApplicationMenuHost(IShell application_shell, ISubMenuToToolStripMenuItemMapper mapper)
        {
            this.mapper = mapper;
            shell = application_shell;
        }

        public void add(ISubMenu menu_to_add)
        {
            //shell.add_to_main_menu(mapper.map_from(menu_to_add));
            shell.region<MenuStrip>(x => x.Items.Add(mapper.map_from(menu_to_add)));
        }
    }
}