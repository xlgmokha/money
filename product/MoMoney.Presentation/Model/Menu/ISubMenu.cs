using System.Collections.Generic;
using System.Windows.Forms;

namespace MoMoney.Presentation.Model.Menu
{
    public interface ISubMenu
    {
        string name { get; }
        IEnumerable<IMenuItem> all_menu_items();
        void add_to(MenuStrip strip);
    }
}