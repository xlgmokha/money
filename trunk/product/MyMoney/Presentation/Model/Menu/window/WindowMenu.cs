using System.Collections.Generic;
using MoMoney.Presentation.Model.Menu.File.Commands;

namespace MoMoney.Presentation.Model.Menu.window
{
    public interface IWindowMenu : ISubMenu
    {
    }

    public class WindowMenu : SubMenu, IWindowMenu
    {
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