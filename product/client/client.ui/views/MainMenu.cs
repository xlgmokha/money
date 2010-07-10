using System.Windows.Controls;

namespace presentation.windows.views
{
    public class MainMenu : Menu
    {
        public MenuItem add(string header)
        {
            var menu_item = new MenuItem {Header = header};
            Items.Add(menu_item);
            return menu_item;
        }
    }
}