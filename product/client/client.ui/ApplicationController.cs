using System.Windows;

namespace presentation.windows
{
    public interface ApplicationController
    {
        void add_tab<Presenter, Tab>() where Presenter : TabPresenter where Tab : FrameworkElement, Tab<Presenter>, new();
        void launch_dialog<Presenter, Dialog>() where Presenter : DialogPresenter where Dialog : FrameworkElement, Dialog<Presenter>, new();
        void load_region<Presenter, Region>() where Presenter : windows.Presenter where Region : FrameworkElement, View<Presenter>, new();
    }
}