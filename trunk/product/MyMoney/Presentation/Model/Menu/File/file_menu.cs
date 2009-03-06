using System.Collections.Generic;
using MoMoney.Presentation.Model.keyboard;
using MoMoney.Presentation.Model.Menu.File.Commands;
using MoMoney.Presentation.Resources;

namespace MoMoney.Presentation.Model.Menu.File
{
    public interface IFileMenu : ISubMenu
    {
    }

    public class file_menu : IFileMenu
    {
        public IEnumerable<IMenuItem> all_menu_items()
        {
            yield return create
                .a_menu_item()
                .named("&New")
                .that_executes<INewCommand>()
                .represented_by(ApplicationIcons.NewProject)
                .can_be_accessed_with(shortcut_keys.control.and(shortcut_keys.N))
                .build();

            yield return create
                .a_menu_item()
                .named("&Open")
                .that_executes<IOpenCommand>()
                .represented_by(ApplicationIcons.OpenProject)
                .can_be_accessed_with(shortcut_keys.control.and(shortcut_keys.O))
                .build();

            yield return create
                .a_menu_item()
                .named("&Save")
                .that_executes<ISaveCommand>()
                .represented_by(ApplicationIcons.SaveProject)
                .can_be_accessed_with(shortcut_keys.control.and(shortcut_keys.S))
                .build();

            yield return create
                .a_menu_item()
                .named("Save &As...")
                .that_executes<ISaveAsCommand>()
                .represented_by(ApplicationIcons.SaveProjectAs)
                .build();

            yield return create
                .a_menu_item()
                .named("&Close")
                .that_executes<ICloseCommand>()
                .build();

            yield return create.a_menu_item_separator();

            yield return create
                .a_menu_item()
                .named("E&xit")
                .that_executes<IExitCommand>()
                .represented_by(ApplicationIcons.ExitApplication)
                .build();
        }

        public string name
        {
            get { return "&File"; }
        }
    }
}