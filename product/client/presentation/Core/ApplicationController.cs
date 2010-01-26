using MoMoney.Presentation.Views;
using MoMoney.Service.Infrastructure.Eventing;

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
        IEventAggregator broker;

        public ApplicationController(IShell shell, PresenterFactory presenter_factory, IEventAggregator broker)
        {
            this.presenter_factory = presenter_factory;
            this.broker = broker;
            this.shell = shell;
        }

        public void run<Presenter>() where Presenter : IPresenter
        {
            var presenter = presenter_factory.create<Presenter>();
            broker.subscribe(presenter);
            presenter.present(shell);
        }
    }
}