using gorilla.commons.utility;
using MoMoney.Presentation.Views;

namespace MoMoney.Presentation.Core
{
    public interface IApplicationController
    {
        void run<Presenter>() where Presenter : IPresenter;
    }

    public class ApplicationController : IApplicationController, ParameterizedCommand<IPresenter>
    {
        readonly IShell shell;
        PresenterFactory factory;

        public ApplicationController(IShell shell, PresenterFactory factory)
        {
            this.factory = factory;
            this.shell = shell;
        }

        public void run<Presenter>() where Presenter : IPresenter
        {
            run(factory.create<Presenter>());
        }

        public void run(IPresenter presenter)
        {
            presenter.present();
            if (presenter.is_an_implementation_of<IContentPresenter>())
            {
                var content_presenter = presenter.downcast_to<IContentPresenter>();
                shell.add(content_presenter.View);
            }
        }
    }
}