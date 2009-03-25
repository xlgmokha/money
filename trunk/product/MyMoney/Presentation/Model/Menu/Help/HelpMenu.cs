using System.Collections.Generic;
using MoMoney.Presentation.Model.Menu.Help.commands;
using MoMoney.Presentation.Presenters.Commands;
using MoMoney.Presentation.Presenters.Shell;
using MoMoney.Presentation.Presenters.updates;
using MoMoney.Presentation.Resources;

namespace MoMoney.Presentation.Model.Menu.Help
{
    public interface IHelpMenu : ISubMenu
    {
    }

    public class HelpMenu : IHelpMenu
    {
        readonly IRunPresenterCommand command;

        public HelpMenu(IRunPresenterCommand command)
        {
            this.command = command;
        }

        public IEnumerable<IMenuItem> all_menu_items()
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
                .that_executes(() => command.run<ICheckForUpdatesPresenter>())
                .build();

            yield return Create.a_menu_item_separator();

            yield return Create
                .a_menu_item()
                .named("View Log File")
                .that_executes(() => command.run<ILogFilePresenter>())
                .build();
        }

        public string name
        {
            get { return "&Help"; }
        }
    }
}