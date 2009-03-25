using System.Collections.Generic;
using MoMoney.Presentation.Model.Menu.File;
using MoMoney.Presentation.Model.Menu.Help.commands;
using MoMoney.Presentation.Presenters.Commands;
using MoMoney.Presentation.Presenters.Shell;
using MoMoney.Presentation.Presenters.updates;
using MoMoney.Presentation.Resources;
using MoMoney.Presentation.Views.Menu.Mappers;

namespace MoMoney.Presentation.Model.Menu.Help
{
    public interface IHelpMenu : ISubMenu
    {
    }

    public class HelpMenu : SubMenu, IHelpMenu
    {
        readonly IRunPresenterCommand command;

        public HelpMenu(IRunPresenterCommand command, ISubMenuToToolStripMenuItemMapper mapper) : base(mapper)
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
                .that_executes(() => command.run<ICheckForUpdatesPresenter>())
                .build();

            yield return Create.a_menu_item_separator();

            yield return Create
                .a_menu_item()
                .named("View Log File")
                .that_executes(() => command.run<ILogFilePresenter>())
                .build();
        }
    }
}