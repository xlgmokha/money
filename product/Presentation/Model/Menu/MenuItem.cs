using System;
using System.Windows.Forms;
using Gorilla.Commons.Windows.Forms.Keyboard;
using Gorilla.Commons.Windows.Forms.Resources;

namespace MoMoney.Presentation.Model.Menu
{
    public interface IMenuItem
    {
        ToolStripItem build();
        System.Windows.Forms.MenuItem build_menu_item();
        void refresh();
    }

    public class MenuItem : IMenuItem
    {
        readonly Func<bool> can_be_clicked;
        readonly ToolStripMenuItem item;
        readonly System.Windows.Forms.MenuItem task_tray_item;

        public MenuItem(string name, Action command, HybridIcon icon, ShortcutKey key, Func<bool> can_be_clicked)
        {
            this.can_be_clicked = can_be_clicked;

            item = new ToolStripMenuItem(name)
                       {
                           Image = icon,
                           ShortcutKeys = key,
                           Enabled = can_be_clicked()
                       };
            item.Click += (o, e) => command();

            task_tray_item = new System.Windows.Forms.MenuItem(name) {ShowShortcut = true, Enabled = can_be_clicked()};
            task_tray_item.Click += (o, e) => command();
        }

        public ToolStripItem build()
        {
            return item;
        }

        public System.Windows.Forms.MenuItem build_menu_item()
        {
            return task_tray_item;
        }

        public void refresh()
        {
            item.Enabled = can_be_clicked();
            task_tray_item.Enabled = can_be_clicked();
            //this.log().debug("item: {0}, is enabled: {1}", item.Text, item.Enabled);
        }
    }
}