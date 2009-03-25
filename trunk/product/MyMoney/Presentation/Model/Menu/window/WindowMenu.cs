using System.Collections.Generic;
using MoMoney.Presentation.Model.Menu.File;
using MoMoney.Presentation.Model.Menu.File.Commands;
using MoMoney.Presentation.Views.Menu.Mappers;

namespace MoMoney.Presentation.Model.Menu.window
{
    public interface IWindowMenu : ISubMenu
    {
    }

    public class WindowMenu : SubMenu, IWindowMenu
    {
        public WindowMenu(ISubMenuToToolStripMenuItemMapper mapper) : base(mapper)
        {
        }

        public override string name
        {
            get { return "&Window"; }
        }

        public override IEnumerable<IMenuItem> all_menu_items()
        {
            yield return Create
                .a_menu_item()
                .named("&Close Window")
                .that_executes<ICloseWindowCommand>()
                .build();
        }
    }
}