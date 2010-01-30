using MoMoney.Presentation;
using MoMoney.Presentation.Core;
using momoney.presentation.model.eventing;
using momoney.presentation.views;
using MoMoney.Presentation.Views;
using MoMoney.Service.Infrastructure.Eventing;

namespace momoney.presentation.presenters
{
    public class UnhandledErrorPresenter : IModule, DialogPresenter, EventSubscriber<UnhandledErrorOccurred>
    {
        readonly IUnhandledErrorView view;
        readonly IRestartCommand restart;

        public UnhandledErrorPresenter(IUnhandledErrorView view, IRestartCommand command)
        {
            this.view = view;
            restart = command;
        }

        public void present(Shell shell) {}

        public void notify(UnhandledErrorOccurred message)
        {
            view.attach_to(this);
            view.display(message.error);
        }

        public void restart_application()
        {
            restart.run();
        }

        public void run() {}
    }
}