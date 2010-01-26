using System.Collections;
using System.Collections.Generic;
using gorilla.commons.utility;
using MoMoney.Presentation.Model.Menu.File;
using MoMoney.Presentation.Model.Menu.Help;
using MoMoney.Presentation.Model.Menu.window;

namespace MoMoney.Presentation.Model.Menu
{
    public interface ISubMenuRegistry : Registry<ISubMenu> {}

    public class SubMenuRegistry : ISubMenuRegistry
    {
        readonly IFileMenu file_menu;
        readonly IWindowMenu window_menu;
        readonly IHelpMenu help_menu;

        public SubMenuRegistry(IFileMenu file_menu, IWindowMenu window_menu, IHelpMenu help_menu)
        {
            this.file_menu = file_menu;
            this.window_menu = window_menu;
            this.help_menu = help_menu;
        }

        public IEnumerable<ISubMenu> all()
        {
            yield return file_menu;
            yield return window_menu;
            yield return help_menu;
        }

        public IEnumerator<ISubMenu> GetEnumerator()
        {
            return all().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}