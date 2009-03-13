using System;
using System.ComponentModel;
using System.Windows.Forms;
using MoMoney.Presentation.Views.core;

namespace MoMoney.Presentation.Views.Shell
{
    public interface IShell : IWin32Window, ISynchronizeInvoke, IContainerControl, IBindableComponent, IDropTarget
    {
        string Text { get; set; }
        void add(IDockedContentView view);
        void region<T>(Action<T> action) where T : Control;
        void close_the_active_window();
        void close_all_windows();
    }
}