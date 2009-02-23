using MyMoney.Presentation.Resources;
using MyMoney.Presentation.Views.Shell;

namespace MyMoney.Presentation.Presenters.Shell
{
    public interface IStatusBarPresenter : IPresentationModule
    {
    }

    public class status_bar_presenter : IStatusBarPresenter
    {
        readonly IStatusBarView view;

        public status_bar_presenter(IStatusBarView view)
        {
            this.view = view;
        }

        public void run()
        {
            view.Display(ApplicationIcons.ApplicationReady, "Ready");
        }
    }
}