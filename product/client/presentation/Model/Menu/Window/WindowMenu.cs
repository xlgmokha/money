using System.Collections.Generic;
using momoney.presentation.model.menu.file;
using momoney.presentation.resources;

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
                .represented_by(ApplicationIcons.CloseWindow)
                .that_executes<ICloseWindowCommand>()
                .build();
        }
    }
}