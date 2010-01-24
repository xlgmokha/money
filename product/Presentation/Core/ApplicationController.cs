using MoMoney.Presentation.Views;

namespace MoMoney.Presentation.Core
{
    public interface IApplicationController
    {
        void run<Presenter>() where Presenter : IPresenter;
    }

    public class ApplicationController : IApplicationController
    {
        IShell shell;
        PresenterFactory presenter_factory;

        public ApplicationController(IShell shell, PresenterFactory presenter_factory)
        {
            this.presenter_factory = presenter_factory;
            this.shell = shell;
        }

        public void run<Presenter>() where Presenter : IPresenter
        {
            presenter_factory.create<Presenter>().present(shell);
        }
    }
}