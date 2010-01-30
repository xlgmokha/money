using System.Collections.Generic;
using System.Windows.Forms;
using gorilla.commons.utility;
using MoMoney.Presentation.Winforms.Helpers;

namespace MoMoney.Presentation.Model.Menu
{
    public abstract class SubMenu : ISubMenu
    {
        public abstract string name { get; }

        public abstract IEnumerable<IMenuItem> all_menu_items();

        public void add_to(MenuStrip strip)
        {
            using (new SuspendLayout(strip))
            {
                var menu_item = new ToolStripMenuItem(name);
                strip.Items.Add(menu_item);
                all_menu_items().each(x => menu_item.DropDownItems.Add(x.build()));
            }
        }
    }
}