using System;
using System.ComponentModel;
using System.Windows.Forms;
using MoMoney.Presentation.Presenters.Shell;
using MoMoney.Presentation.Views.Core;

namespace MoMoney.Presentation.Views.Shell
{
    public interface IShell : IWin32Window, ISynchronizeInvoke, IContainerControl, IBindableComponent, IDropTarget
    {
        void attach_to(IApplicationShellPresenter presenter);
        void add(IDockedContentView view);
        void region<T>(Action<T> action) where T : IComponent;
        void close_the_active_window();
        void close_all_windows();
    }
}