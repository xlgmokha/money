using System.Collections.Generic;
using MyMoney.Presentation.Model.Menu.Help.commands;
using MyMoney.Presentation.Resources;

namespace MyMoney.Presentation.Model.Menu.Help
{
    public interface IHelpMenu : ISubMenu
    {}

    public class help_menu : IHelpMenu
    {
        public IEnumerable<IMenuItem> all_menu_items()
        {
            yield return create
                .a_menu_item()
                .named("&About")
                .that_executes<IDisplayInformationAboutTheApplication>()
                .represented_by(ApplicationIcons.About)
                .build();
        }

        public string name
        {
            get { return "&Help"; }
        }
    }
}