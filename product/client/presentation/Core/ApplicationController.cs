using MoMoney.Presentation.Views;
using MoMoney.Service.Infrastructure.Eventing;

namespace MoMoney.Presentation.Core
{
    public interface IApplicationController
    {
        void run<Presenter>() where Presenter : Core.Presenter;
    }

    public class ApplicationController : IApplicationController
    {
        Shell shell;
        PresenterFactory presenter_factory;
        EventAggregator broker;

        public ApplicationController(Shell shell, PresenterFactory presenter_factory, EventAggregator broker)
        {
            this.presenter_factory = presenter_factory;
            this.broker = broker;
            this.shell = shell;
        }

        public void run<Presenter>() where Presenter : Core.Presenter
        {
            var presenter = presenter_factory.create<Presenter>();
            broker.subscribe(presenter);
            presenter.present(shell);
        }
    }
}