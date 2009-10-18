using System.ComponentModel;
using System.Windows.Forms;
using MoMoney.Presentation.Presenters;

namespace MoMoney.Presentation.Views
{
    public interface IShell : IWin32Window, ISynchronizeInvoke, IContainerControl, IBindableComponent, IDropTarget,
                              IRegionManager
    {
        void attach_to(IApplicationShellPresenter presenter);
        void add(IDockedContentView view);
        void close_the_active_window();
        void close_all_windows();
    }
}