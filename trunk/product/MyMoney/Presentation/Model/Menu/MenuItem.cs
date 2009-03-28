using System;
using System.Windows.Forms;
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
        public MenuItem(string name, Action command, HybridIcon icon, ShortcutKey key,
                        Func<bool> can_be_clicked)
        {
            this.name = name;
            this.command = command;
            this.icon = icon;
            this.key = key;
            this.can_be_clicked = can_be_clicked;
        }

        string name { get; set; }
        Action command { get; set; }
        HybridIcon icon { get; set; }
        ShortcutKey key { get; set; }
        readonly Func<bool> can_be_clicked;

        public ToolStripItem build()
        {
            var item = new ToolStripMenuItem(name)
                           {
                               Image = icon,
                               ShortcutKeys = key,
                               Enabled = can_be_clicked()
                           };
            item.Click += (o, e) => command();
            return item;
        }

        public System.Windows.Forms.MenuItem build_menu_item()
        {
            var item = new System.Windows.Forms.MenuItem(name) {ShowShortcut = true, Enabled = can_be_clicked()};
            item.Click += (sender, e) => command();
            //item.Popup += (o,e)=> {}
            item.DrawItem += (sender, args) => item.Enabled = can_be_clicked();
            return item;
        }
    }
}