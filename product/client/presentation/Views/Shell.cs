using System.ComponentModel;
using System.Windows.Forms;
using momoney.presentation.presenters;

namespace momoney.presentation.views
{
    public interface Shell : IWin32Window, ISynchronizeInvoke, IContainerControl, IBindableComponent, IDropTarget,
                             IRegionManager
    {
        void attach_to(ApplicationShellPresenter presenter);
        void add(ITab view);
        void close_the_active_window();
        void close_all_windows();
    }
}