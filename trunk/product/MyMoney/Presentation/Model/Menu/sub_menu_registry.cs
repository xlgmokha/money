using System.Collections.Generic;
using MoMoney.Domain.Core;
using MoMoney.Presentation.Model.Menu.File;
using MoMoney.Presentation.Model.Menu.Help;
using MoMoney.Presentation.Model.Menu.window;

namespace MoMoney.Presentation.Model.Menu
{
    public interface ISubMenuRegistry : IRegistry<ISubMenu>
    {}

    public class sub_menu_registry : ISubMenuRegistry
    {
        private readonly IFileMenu file_menu;
        private readonly IWindowMenu window_menu;
        private readonly IHelpMenu help_menu;

        public sub_menu_registry(IFileMenu file_menu, IWindowMenu window_menu, IHelpMenu help_menu)
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
    }
}