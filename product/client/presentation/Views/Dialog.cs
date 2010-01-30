using MoMoney.Presentation.Core;

namespace momoney.presentation.views
{
    public interface Dialog<TPresenter> : View<TPresenter> where TPresenter : DialogPresenter
    {
    }
}