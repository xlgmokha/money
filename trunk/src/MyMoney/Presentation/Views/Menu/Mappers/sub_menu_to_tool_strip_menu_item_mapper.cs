using System.Windows.Forms;
using MyMoney.Presentation.Model.Menu;
using MyMoney.Utility.Core;

namespace MyMoney.Presentation.Views.Menu.Mappers
{
    public interface ISubMenuToToolStripMenuItemMapper : IMapper<ISubMenu, ToolStripMenuItem>
    {}

    public class sub_menu_to_tool_strip_menu_item_mapper : ISubMenuToToolStripMenuItemMapper
    {
        public ToolStripMenuItem map_from(ISubMenu item)
        {
            var toolStripMenuItem = new ToolStripMenuItem(item.name);
            foreach (var menuItem in item.all_menu_items()) {
                toolStripMenuItem.DropDownItems.Add(menuItem.build());
            }
            return toolStripMenuItem;
        }
    }
}