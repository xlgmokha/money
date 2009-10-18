using System.Collections.Generic;
using MoMoney.Presentation.Model.Menu.File;
using MoMoney.Presentation.Winforms.Resources;

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