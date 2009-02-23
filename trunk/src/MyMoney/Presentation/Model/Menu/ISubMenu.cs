using System.Collections.Generic;

namespace MyMoney.Presentation.Model.Menu
{
    public interface ISubMenu
    {
        string name { get; }
        IEnumerable<IMenuItem> all_menu_items();
    }
}