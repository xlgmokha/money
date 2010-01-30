namespace MoMoney.Presentation.Core
{
    public interface PresenterFactory
    {
        TPresenter create<TPresenter>() where TPresenter : Presenter;
    }
}