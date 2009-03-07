using System.ComponentModel.Composition;
using System.Windows.Forms;
using Castle.Core;
using MoMoney.Infrastructure.interceptors;
using MoMoney.Presentation.Resources;
using MoMoney.Presentation.Views.core;

namespace MoMoney.Presentation.Views.Shell
{
    [Export(typeof (IShell))]
    //[Interceptor(typeof (ISynchronizedInterceptor))]
    public partial class ApplicationShell : ApplicationWindow, IShell
    {
        public ApplicationShell()
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
            view.add_to(ux_dock_panel);
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
            while (ux_dock_panel.Contents.Count > 0)
            {
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