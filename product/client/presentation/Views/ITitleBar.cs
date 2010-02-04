using momoney.presentation.presenters;
using momoney.presentation.views;

namespace MoMoney.Presentation.Views
{
    public interface ITitleBar : View<TitleBarPresenter>
    {
        void display(string title);
        void append_asterik();
        void remove_asterik();
    }
}