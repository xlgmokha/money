using System;
using System.Windows.Forms;
using Gorilla.Commons.Utility.Core;
using MoMoney.Infrastructure.Container;
using MoMoney.Infrastructure.eventing;
using MoMoney.Infrastructure.Threading;
using MoMoney.Presentation.Resources;

namespace MoMoney.Presentation.Model.Menu
{
    public class ToolBarItemBuilder : IToolbarItemBuilder, IToolbarButton
    {
        readonly IDependencyRegistry registry;
        readonly ToolStripButton item;
        readonly ICommandProcessor processor;
        Func<bool> the_condition;

        public ToolBarItemBuilder(IDependencyRegistry registry, IEventAggregator aggregator, ICommandProcessor processor)
        {
            this.registry = registry;
            this.processor = processor;
            aggregator.subscribe(this);
            the_condition = () => true;
            item = new ToolStripButton {};
        }

        public IToolbarItemBuilder with_tool_tip_text_as(string text)
        {
            item.Text = text;
            return this;
        }

        public IToolbarItemBuilder when_clicked_executes<Command>() where Command : ICommand
        {
            item.Click += (sender, args) => processor.add(registry.get_a<Command>());
            return this;
        }

        public IToolbarItemBuilder displays_icon(HybridIcon icon)
        {
            item.Image = icon;
            return this;
        }

        public IToolbarItemBuilder can_be_clicked_when(Func<bool> condition)
        {
            the_condition = condition;
            item.Enabled = condition();
            return this;
        }

        public IToolbarButton button()
        {
            return this;
        }

        public void add_to(ToolStrip tool_strip)
        {
            tool_strip.Items.Add(item);
        }

        public void refresh()
        {
            item.Enabled = the_condition();
        }
    }
}