using MoMoney.Presentation.Core;
using MoMoney.Presentation.Views;

namespace momoney.presentation.views
{
    public interface Dialog<TPresenter> : View<TPresenter> where TPresenter : DialogPresenter
    {
        void show_dialog(Shell parent_window);
        void Close();
    }
}