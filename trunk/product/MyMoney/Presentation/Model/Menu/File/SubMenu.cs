using System.Collections.Generic;
using System.Windows.Forms;
using MoMoney.Presentation.Views.Menu.Mappers;

namespace MoMoney.Presentation.Model.Menu.File
{
    public abstract class SubMenu : ISubMenu
    {
        readonly ISubMenuToToolStripMenuItemMapper mapper;

        protected SubMenu(ISubMenuToToolStripMenuItemMapper mapper)
        {
            this.mapper = mapper;
        }

        public abstract string name { get; }

        public abstract IEnumerable<IMenuItem> all_menu_items();

        public void add_to(MenuStrip strip)
        {
            strip.Items.Add(mapper.map_from(this));
        }
    }
}