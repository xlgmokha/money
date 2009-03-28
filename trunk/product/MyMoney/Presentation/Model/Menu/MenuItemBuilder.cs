using System;
using MoMoney.Infrastructure.Container;
using MoMoney.Infrastructure.eventing;
using MoMoney.Presentation.Model.keyboard;
using MoMoney.Presentation.Resources;
using MoMoney.Utility.Core;

namespace MoMoney.Presentation.Model.Menu
{
    public interface IMenuItemBuilder : IBuilder<IMenuItem>
    {
        IMenuItemBuilder named(string name);
        IMenuItemBuilder that_executes<TheCommand>() where TheCommand : ICommand;
        IMenuItemBuilder that_executes(Action action);
        IMenuItemBuilder represented_by(HybridIcon project);
        IMenuItemBuilder can_be_accessed_with(ShortcutKey hot_key);
        IMenuItemBuilder can_be_clicked_when(Func<bool> predicate);
    }

    public class MenuItemBuilder : IMenuItemBuilder
    {
        readonly IDependencyRegistry registry;
        Func<bool> can_be_clicked = () => true;
        IEventAggregator aggregator;

        public MenuItemBuilder(IDependencyRegistry registry, IEventAggregator aggregator)
        {
            name_of_the_menu = "Unknown";
            command_to_execute = () => { };
            this.registry = registry;
            this.aggregator = aggregator;
            icon = ApplicationIcons.Empty;
            key = ShortcutKeys.none;
        }

        public string name_of_the_menu { get; private set; }
        public Action command_to_execute { get; private set; }
        public HybridIcon icon { get; private set; }
        public ShortcutKey key { get; private set; }

        public IMenuItemBuilder named(string name)
        {
            name_of_the_menu = name;
            return this;
        }

        public IMenuItemBuilder that_executes<TheCommand>() where TheCommand : ICommand
        {
            command_to_execute = () => registry.get_a<TheCommand>().run();
            return this;
        }

        public IMenuItemBuilder that_executes(Action action)
        {
            command_to_execute = action;
            return this;
        }

        public IMenuItemBuilder represented_by(HybridIcon project)
        {
            icon = project;
            return this;
        }

        public IMenuItemBuilder can_be_accessed_with(ShortcutKey hot_key)
        {
            key = hot_key;
            return this;
        }

        public IMenuItemBuilder can_be_clicked_when(Func<bool> predicate)
        {
            can_be_clicked = predicate;
            return this;
        }

        public IMenuItem build()
        {
            var item = new MenuItem(name_of_the_menu, command_to_execute, icon, key, can_be_clicked);
            aggregator.subscribe(item);
            return item;
        }
    }
}