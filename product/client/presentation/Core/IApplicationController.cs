namespace MoMoney.Presentation.Core
{
    public interface IApplicationController
    {
        void run<TPresenter>() where TPresenter : Presenter;
        void launch_dialog<TPresenter>() where TPresenter : DialogPresenter;
    }
}