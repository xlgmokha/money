using momoney.presentation.presenters;

namespace momoney.presentation.views
{
    public interface Shell : IRegionManager
    {
        void attach_to(ApplicationShellPresenter presenter);
        void add(ITab view);
        void close_the_active_window();
        void close_all_windows();
    }
}