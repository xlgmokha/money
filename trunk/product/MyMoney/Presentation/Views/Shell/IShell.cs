using System.ComponentModel;
using System.Windows.Forms;
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
}