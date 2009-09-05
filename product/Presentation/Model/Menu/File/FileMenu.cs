using System.Collections.Generic;
using MoMoney.Presentation.Model.Menu.File.Commands;
using MoMoney.Presentation.Model.Projects;
using MoMoney.Presentation.Winforms.Keyboard;
using MoMoney.Presentation.Winforms.Resources;

namespace MoMoney.Presentation.Model.Menu.File
{
    public interface IFileMenu : ISubMenu
    {
    }

    public class FileMenu : SubMenu, IFileMenu
    {
        readonly IProjectController project;

        public FileMenu(IProjectController project)
        {
            this.project = project;
        }

        public override string name
        {
            get { return "&File"; }
        }

        public override IEnumerable<IMenuItem> all_menu_items()
        {
            yield return Create
                .a_menu_item()
                .named("&New")
                .that_executes<INewCommand>()
                .represented_by(ApplicationIcons.NewProject)
                .can_be_accessed_with(ShortcutKeys.control.and(ShortcutKeys.N))
                .build();

            yield return Create
                .a_menu_item()
                .named("&Open")
                .that_executes<IOpenCommand>()
                .represented_by(ApplicationIcons.OpenProject)
                .can_be_accessed_with(ShortcutKeys.control.and(ShortcutKeys.O))
                .build();

            yield return Create
                .a_menu_item()
                .named("&Save")
                .that_executes<ISaveCommand>()
                .represented_by(ApplicationIcons.SaveProject)
                .can_be_clicked_when(() => project.has_unsaved_changes())
                .can_be_accessed_with(ShortcutKeys.control.and(ShortcutKeys.S))
                .build();

            yield return Create
                .a_menu_item()
                .named("Save &As...")
                .that_executes<ISaveAsCommand>()
                .can_be_clicked_when(() => project.has_unsaved_changes())
                .represented_by(ApplicationIcons.SaveProjectAs)
                .build();

            yield return Create
                .a_menu_item()
                .named("&Close")
                .can_be_clicked_when(() => project.is_open())
                .represented_by(ApplicationIcons.CloseProject)
                .that_executes<ICloseCommand>()
                .build();

            yield return Create.a_menu_item_separator();

            yield return Create
                .a_menu_item()
                .named("E&xit")
                .that_executes<IExitCommand>()
                .represented_by(ApplicationIcons.ExitApplication)
                .build();
        }
    }
}