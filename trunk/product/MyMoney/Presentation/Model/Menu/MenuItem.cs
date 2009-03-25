using System;
using System.Windows.Forms;
using MoMoney.Infrastructure.eventing;
using MoMoney.Presentation.Model.keyboard;
using MoMoney.Presentation.Resources;

namespace MoMoney.Presentation.Model.Menu
{
    public interface IMenuItem
    {
        ToolStripItem build();
        System.Windows.Forms.MenuItem build_menu_item();
    }

    public class MenuItem : IMenuItem
    {
        public MenuItem(string name, Action command, HybridIcon underlying_icon, ShortcutKey key, Func<bool> can_be_clicked)
        {
            this.name = name;
            this.command = command;
            this.underlying_icon = underlying_icon;
            this.key = key;
            this.can_be_clicked = can_be_clicked;
        }

        public string name { get; private set; }
        Action command { get; set; }
        HybridIcon underlying_icon { get; set; }
        ShortcutKey key { get; set; }
        readonly Func<bool> can_be_clicked;
        ToolStripMenuItem tool_strip_menu_item;
        System.Windows.Forms.MenuItem menu_item;

        public ToolStripItem build()
        {
            tool_strip_menu_item = new ToolStripMenuItem(name);
            tool_strip_menu_item.Click += ((o, e) => command());
            tool_strip_menu_item.Image = underlying_icon;
            tool_strip_menu_item.ShortcutKeys = key;
            tool_strip_menu_item.Enabled = can_be_clicked();
            return tool_strip_menu_item;
        }

        public System.Windows.Forms.MenuItem build_menu_item()
        {
            menu_item = new System.Windows.Forms.MenuItem(name);
            menu_item.Click += ((sender, e) => command());
            menu_item.ShowShortcut = true;
            menu_item.Enabled = can_be_clicked();
            return menu_item;
        }
    }
}