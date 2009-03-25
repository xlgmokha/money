using System;
using System.Windows.Forms;
using MoMoney.Infrastructure.Container;
using MoMoney.Presentation.Resources;
using MoMoney.Utility.Core;

namespace MoMoney.Presentation.Model.Menu
{
    public class ToolBarItemBuilder : IToolbarItemBuilder, IToolbarButton
    {
        readonly IDependencyRegistry registry;
        string tooltip_text;
        ICommand the_command;
        HybridIcon icon_to_display;
        Func<bool> the_condition;

        public ToolBarItemBuilder(IDependencyRegistry registry)
        {
            this.registry = registry;
            tooltip_text = "";
            the_command = new EmptyCommand();
            icon_to_display = ApplicationIcons.Empty;
            the_condition = () => true;
        }

        public IToolbarItemBuilder with_tool_tip_text_as(string text)
        {
            tooltip_text = text;
            return this;
        }

        public IToolbarItemBuilder when_clicked_executes<Command>() where Command : ICommand
        {
            the_command = registry.get_a<Command>();
            return this;
        }

        public IToolbarItemBuilder displays_icon(HybridIcon icon)
        {
            icon_to_display = icon;
            return this;
        }

        public IToolbarItemBuilder can_be_clicked_when(Func<bool> condition)
        {
            the_condition = condition;
            return this;
        }

        public IToolbarButton button()
        {
            return this;
        }

        public void add_to(ToolStrip tool_strip)
        {
            var item = new ToolStripButton
                           {
                               ToolTipText = tooltip_text,
                               Image = icon_to_display,
                               Enabled = the_condition()
                           };
            item.Click += (sender, args) => the_command.run();
            tool_strip.Items.Add(item);
        }
    }
}