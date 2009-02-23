using MyMoney.Infrastructure.Container;
using MyMoney.Presentation.Model.keyboard;
using MyMoney.Presentation.Resources;
using MyMoney.Utility.Core;

namespace MyMoney.Presentation.Model.Menu
{
    public interface IMenuItemBuilder
    {
        IMenuItemBuilder named(string name);
        IMenuItemBuilder that_executes<TheCommand>() where TheCommand : ICommand;
        IMenuItemBuilder represented_by(HybridIcon project);
        IMenuItemBuilder can_be_accessed_with(shortcut_key hot_key);
        IMenuItem build();
    }

    public class menu_item_builder : IMenuItemBuilder
    {
        private readonly IDependencyRegistry registry;

        public menu_item_builder(IDependencyRegistry registry)
        {
            name_of_the_menu = "Unknown";
            command_to_execute = new empty_command();
            this.registry = registry;
            icon = ApplicationIcons.Empty;
            key = shortcut_keys.none;
        }

        public string name_of_the_menu { get; private set; }
        public ICommand command_to_execute { get; private set; }
        public HybridIcon icon { get; private set; }
        public shortcut_key key { get; private set; }

        public IMenuItemBuilder named(string name)
        {
            name_of_the_menu = name;
            return this;
        }

        public IMenuItemBuilder that_executes<TheCommand>() where TheCommand : ICommand
        {
            command_to_execute = registry.find_an_implementation_of<TheCommand>();
            return this;
        }

        public IMenuItemBuilder represented_by(HybridIcon project)
        {
            icon = project;
            return this;
        }

        public IMenuItemBuilder can_be_accessed_with(shortcut_key hot_key)
        {
            key = hot_key;
            return this;
        }

        public IMenuItem build()
        {
            return new menu_item(name_of_the_menu, command_to_execute, icon, key);
        }
    }
}