using System.Windows.Forms;
using MyMoney.Infrastructure.Container;
using MyMoney.Presentation.Resources;
using MyMoney.Utility.Core;

namespace MyMoney.Presentation.Model.Menu
{
    public interface IToolbarItemBuilder
    {
        IToolbarItemBuilder with_tool_tip_text_as(string text);
        IToolbarItemBuilder when_clicked_executes<T>() where T : ICommand;
        IToolbarItemBuilder displays_icon(HybridIcon project);
        ToolStripItem build();
    }

    public class tool_bar_item_builder : IToolbarItemBuilder
    {
        private readonly IDependencyRegistry registry;
        private string tooltip_text;
        private ICommand the_command;
        private HybridIcon icon_to_display;

        public tool_bar_item_builder(IDependencyRegistry registry)
        {
            this.registry = registry;
            tooltip_text = "";
            the_command = new empty_command();
            icon_to_display = ApplicationIcons.Empty;
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

        public ToolStripItem build()
        {
            var tool_strip_menu_item = new ToolStripButton {ToolTipText = tooltip_text};
            tool_strip_menu_item.Click += delegate { the_command.run(); };
            tool_strip_menu_item.Image = icon_to_display;
            return tool_strip_menu_item;
        }
    }
}