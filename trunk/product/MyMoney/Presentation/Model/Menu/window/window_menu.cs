using System.Collections.Generic;
using MoMoney.Presentation.Model.Menu.File.Commands;

namespace MoMoney.Presentation.Model.Menu.window
{
    public interface IWindowMenu : ISubMenu
    {
    }

    public class window_menu : IWindowMenu
    {
        public string name
        {
            get { return "&Window"; }
        }

        public IEnumerable<IMenuItem> all_menu_items()
        {
            yield return create
                .a_menu_item()
                .named("&Close Window")
                .that_executes<ICloseWindowCommand>()
                .build();
        }
    }
}