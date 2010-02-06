using System;
using System.Windows.Controls;
using presentation.windows.presenters;

namespace presentation.windows.views
{
    static public class MenuItemExtensions
    {
        static public MenuItem add(this MenuItem item, string header, Action action)
        {
            var menu_item = new MenuItem {Header = header, Command = new SimpleCommand(action)};
            item.Items.Add(menu_item);
            return menu_item;
        }
    }
}