using System.Windows;

namespace presentation.windows
{
    public interface ApplicationController
    {
        void add_tab<Presenter, View>() where Presenter : TabPresenter where View : FrameworkElement, Tab<Presenter>, new();
    }
}