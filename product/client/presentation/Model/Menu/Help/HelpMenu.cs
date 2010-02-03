using System.Collections.Generic;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.model.menu.help;
using momoney.presentation.presenters;
using MoMoney.Presentation.Winforms.Resources;

namespace MoMoney.Presentation.Model.Menu.Help
{
    public interface IHelpMenu : ISubMenu
    {
    }

    public class HelpMenu : SubMenu, IHelpMenu
    {
        readonly IApplicationController command;

        public HelpMenu(IApplicationController command)
        {
            this.command = command;
        }

        public override string name
        {
            get { return "&Help"; }
        }

        public override IEnumerable<IMenuItem> all_menu_items()
        {
            yield return Create
                .a_menu_item()
                .named("&About")
                .that_executes<IDisplayInformationAboutTheApplication>()
                .represented_by(ApplicationIcons.About)
                .build();

            yield return Create
                .a_menu_item()
                .named("Check For Updates...")
                .represented_by(ApplicationIcons.Update)
                .that_executes(() => command.launch_dialog<CheckForUpdatesPresenter>())
                .build();

            yield return Create.a_menu_item_separator();

            yield return Create
                .a_menu_item()
                .named("View Log File")
                .represented_by(ApplicationIcons.ViewLog)
                .that_executes(() => command.run<LogFilePresenter>())
                .build();
        }
    }
}