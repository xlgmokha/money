using momoney.presentation.views;

namespace MoMoney.Presentation.Core
{
    public interface ViewFactory
    {
        View<TPresenter> create_for<TPresenter>() where TPresenter : Presenter;
    }
}