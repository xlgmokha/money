using System;
using System.Windows.Forms;
using MoMoney.Infrastructure.Extensions;
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
        public MenuItem(string name, Action command, HybridIcon underlying_icon, ShortcutKey key,
                        Func<bool> can_be_clicked)
        {
            this.name = name;
            this.command = command;
            this.underlying_icon = underlying_icon;
            this.key = key;
            this.can_be_clicked = can_be_clicked;
        }

        string name { get; set; }
        Action command { get; set; }
        HybridIcon underlying_icon { get; set; }
        ShortcutKey key { get; set; }
        readonly Func<bool> can_be_clicked;

        public ToolStripItem build()
        {
            var item = new ToolStripMenuItem(name)
                           {
                               Image = underlying_icon,
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
            this.log().debug("{0} can be clicked? {1}", name, can_be_clicked());
            return item;
        }
    }
}