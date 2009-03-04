using System.Windows.Forms;
using MyMoney.Presentation.Model.Menu;
using MyMoney.Utility.Core;
using MyMoney.Utility.Extensions;

namespace MyMoney.Presentation.Views.Menu.Mappers
{
    public interface ISubMenuToToolStripMenuItemMapper : IMapper<ISubMenu, ToolStripMenuItem>
    {
    }

    public class SubMenuToToolStripMenuItemMapper : ISubMenuToToolStripMenuItemMapper
    {
        public ToolStripMenuItem map_from(ISubMenu item)
        {
            var tool_strip_menu_item = new ToolStripMenuItem(item.name);
            item.all_menu_items().each(x => tool_strip_menu_item.DropDownItems.Add(x.build()));
            return tool_strip_menu_item;
        }
    }
}