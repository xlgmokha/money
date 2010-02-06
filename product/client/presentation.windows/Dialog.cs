using System.Windows;

namespace presentation.windows
{
    public interface Dialog<TPresenter> : View<TPresenter> where TPresenter : DialogPresenter
    {
        void show_dialog(Window parent);
        void Close();
    }
}