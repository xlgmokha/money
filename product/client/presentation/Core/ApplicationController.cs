using momoney.presentation.views;
using MoMoney.Presentation.Views;
using MoMoney.Service.Infrastructure.Eventing;

namespace MoMoney.Presentation.Core
{
    public class ApplicationController : IApplicationController
    {
        Shell shell;
        PresenterFactory presenter_factory;
        EventAggregator broker;
        ViewFactory view_factory;

        public ApplicationController(Shell shell, PresenterFactory presenter_factory, EventAggregator broker, ViewFactory view_factory)
        {
            this.presenter_factory = presenter_factory;
            this.view_factory = view_factory;
            this.broker = broker;
            this.shell = shell;
        }

        public void run<TPresenter>() where TPresenter : Presenter
        {
            var presenter = presenter_factory.create<TPresenter>();
            broker.subscribe(presenter);
            view_factory.create_for<TPresenter>().attach_to(presenter);
            presenter.present(shell);
        }

        public void launch_dialog<TPresenter>() where TPresenter : DialogPresenter
        {
            var presenter = presenter_factory.create<TPresenter>();
            broker.subscribe(presenter);
            var view = view_factory.create_for<TPresenter>() as Dialog<TPresenter>;
            view.attach_to(presenter);
            presenter.close = () =>
            {
                view.Close();
            };
            presenter.present(shell);
            view.show_dialog(shell);
        }
    }
}