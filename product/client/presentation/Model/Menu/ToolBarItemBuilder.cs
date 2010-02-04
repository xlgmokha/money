using System;
using System.Windows.Forms;
using Gorilla.Commons.Infrastructure.Container;
using momoney.presentation.resources;
using MoMoney.Service.Infrastructure.Eventing;

namespace MoMoney.Presentation.Model.Menu
{
    public class ToolBarItemBuilder : IToolbarItemBuilder, IToolbarButton
    {
        readonly DependencyRegistry registry;
        readonly ToolStripButton item;
        Func<bool> the_condition;

        public ToolBarItemBuilder(DependencyRegistry registry, EventAggregator aggregator)
        {
            this.registry = registry;
            aggregator.subscribe(this);
            the_condition = () => true;
            item = new ToolStripButton {};
        }

        public IToolbarItemBuilder with_tool_tip_text_as(string text)
        {
            item.Text = text;
            return this;
        }

        public IToolbarItemBuilder when_clicked_executes<Command>() where Command : gorilla.commons.utility.Command
        {
            item.Click += (sender, args) => registry.get_a<Command>().run();
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