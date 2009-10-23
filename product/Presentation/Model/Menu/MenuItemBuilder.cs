using System;
using Gorilla.Commons.Infrastructure.Container;
using gorilla.commons.utility;
using MoMoney.Presentation.Winforms.Keyboard;
using MoMoney.Presentation.Winforms.Resources;
using MoMoney.Service.Infrastructure.Eventing;
using MoMoney.Service.Infrastructure.Threading;

namespace MoMoney.Presentation.Model.Menu
{
    public interface IMenuItemBuilder : Builder<IMenuItem>
    {
        IMenuItemBuilder named(string name);
        IMenuItemBuilder that_executes<TheCommand>() where TheCommand : Command;
        IMenuItemBuilder that_executes(Action action);
        IMenuItemBuilder represented_by(HybridIcon project);
        IMenuItemBuilder can_be_accessed_with(ShortcutKey hot_key);
        IMenuItemBuilder can_be_clicked_when(Func<bool> predicate);
    }

    public class MenuItemBuilder : IMenuItemBuilder
    {
        readonly DependencyRegistry registry;
        readonly IEventAggregator aggregator;
        readonly CommandProcessor processor;

        string name_of_the_menu { get; set; }
        Action command_to_execute { get; set; }
        HybridIcon icon { get; set; }
        ShortcutKey key { get; set; }
        Func<bool> can_be_clicked = () => true;

        public MenuItemBuilder(DependencyRegistry registry, IEventAggregator aggregator, CommandProcessor processor)
        {
            name_of_the_menu = "Unknown";
            command_to_execute = () => {};
            this.registry = registry;
            this.processor = processor;
            this.aggregator = aggregator;
            icon = ApplicationIcons.Empty;
            key = ShortcutKeys.none;
        }

        public IMenuItemBuilder named(string name)
        {
            name_of_the_menu = name;
            return this;
        }

        public IMenuItemBuilder that_executes<TheCommand>() where TheCommand : Command
        {
            command_to_execute = () => processor.add(registry.get_a<TheCommand>());
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