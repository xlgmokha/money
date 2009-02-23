using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using MyMoney.Presentation.Resources;
using MyMoney.Presentation.Views.core;

namespace MyMoney.Presentation.Views.Shell
{
    public interface IShell : IWin32Window, ISynchronizeInvoke, IContainerControl, IBindableComponent, IDropTarget
    {
        StatusStrip status_bar();
        void add(IDockedContentView view);
        void add_to_main_menu(ToolStripMenuItem item);
        void add_to_tool_bar(ToolStripItem item);
        void close_the_active_window();
        string Text { get; set; }
        void close_all_windows();
        void clear_menu_items();
    }

    public partial class window_shell : Form, IShell
    {
        public window_shell()
        {
            InitializeComponent();
            Icon = ApplicationIcons.Application;
        }

        public StatusStrip status_bar()
        {
            return ux_status_bar;
        }

        public void add(IDockedContentView view)
        {
            var panel_to_remove = ux_dock_panel
                .Documents
                .SingleOrDefault(x => x.DockHandler.TabText.Equals(view.TabText));
            if (panel_to_remove != null) {
                panel_to_remove.DockHandler.Close();
                panel_to_remove.DockHandler.Dispose();
            }

            view.Show(ux_dock_panel);
        }

        public void add_to_main_menu(ToolStripMenuItem item)
        {
            ux_main_menu_strip.Items.Add(item);
        }

        public void add_to_tool_bar(ToolStripItem item)
        {
            ux_tool_bar_strip.Items.Add(item);
        }

        public void close_the_active_window()
        {
            ux_dock_panel.ActiveDocument.DockHandler.Close();
        }

        public void close_all_windows()
        {
            while (ux_dock_panel.Contents.Count > 0) {
                ux_dock_panel.Contents[0].DockHandler.Close();
            }
        }

        public void clear_menu_items()
        {
            ux_tool_bar_strip.Items.Clear();
            ux_main_menu_strip.Items.Clear();
        }
    }
}