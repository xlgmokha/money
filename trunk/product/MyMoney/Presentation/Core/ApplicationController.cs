using MoMoney.Presentation.Views.Shell;
using MoMoney.Utility.Core;
using MoMoney.Utility.Extensions;

namespace MoMoney.Presentation.Core
{
    public interface IApplicationController : IParameterizedCommand<IPresenter>
    {
        void run<Presenter>() where Presenter : IPresenter;
    }

    public class ApplicationController : IApplicationController
    {
        readonly IPresenterRegistry registered_presenters;
        readonly IShell shell;

        public ApplicationController(IPresenterRegistry registered_presenters, IShell shell)
        {
            this.registered_presenters = registered_presenters;
            this.shell = shell;
        }

        public void run<Presenter>() where Presenter : IPresenter
        {
            run(registered_presenters.find_an_implementation_of<IPresenter, Presenter>());
        }

        public void run(IPresenter presenter)
        {
            if (presenter.is_an_implementation_of<IContentPresenter>())
            {
                shell.add(presenter.downcast_to<IContentPresenter>().View);
            }
            presenter.run();
        }
    }
}