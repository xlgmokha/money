using MyMoney.Presentation.Views.Shell;
using MyMoney.Utility.Core;
using MyMoney.Utility.Extensions;

namespace MyMoney.Presentation.Core
{
    public interface IApplicationController : IParameterizedCommand<IPresenter>
    {
        void run<Presenter>() where Presenter : IPresenter;
    }

    public class application_controller : IApplicationController
    {
        private readonly IPresenterRegistry registered_presenters;
        private readonly IShell shell;

        public application_controller(IPresenterRegistry registered_presenters, IShell shell)
        {
            this.registered_presenters = registered_presenters;
            this.shell = shell;
        }

        public void run<Presenter>() where Presenter : IPresenter
        {
            run(registered_presenters.find_an_implementation_of<Presenter>());
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