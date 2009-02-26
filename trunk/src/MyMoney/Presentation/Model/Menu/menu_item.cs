using System;
using System.Windows.Forms;
using MyMoney.Presentation.Model.keyboard;
using MyMoney.Presentation.Resources;

namespace MyMoney.Presentation.Model.Menu
{
    public interface IMenuItem
    {
        string name { get; }
        void click();
        ToolStripItem build();
        MenuItem build_menu_item();
    }

    public class menu_item : IMenuItem
    {
        public menu_item(string name, Action command, HybridIcon underlying_icon, shortcut_key key)
        {
            this.name = name;
            this.command = command;
            this.underlying_icon = underlying_icon;
            this.key = key;
        }

        public string name { get; private set; }
        public Action command { get; private set; }
        public HybridIcon underlying_icon { get; private set; }
        public shortcut_key key { get; set; }

        public void click()
        {
            command();
        }

        public ToolStripItem build()
        {
            var tool_strip_menu_item = new ToolStripMenuItem(name);
            tool_strip_menu_item.Click += delegate { click(); };
            tool_strip_menu_item.Image = underlying_icon;
            tool_strip_menu_item.ShortcutKeys = key;
            return tool_strip_menu_item;
        }

        public MenuItem build_menu_item()
        {
            var menu_item = new MenuItem(name) {};
            menu_item.Click += ((sender, e) => click());
            return menu_item;
        }
    }
}