using System;
using MoMoney.Presentation.Core;
using momoney.presentation.model.eventing;
using momoney.presentation.views;
using MoMoney.Presentation.Views;
using MoMoney.Service.Infrastructure.Eventing;

namespace momoney.presentation.presenters
{
    public class UnhandledErrorPresenter : DialogPresenter, EventSubscriber<UnhandledErrorOccurred>
    {
        IUnhandledErrorView view;
        IRestartCommand restart;
        Shell shell;

        public UnhandledErrorPresenter(IUnhandledErrorView view, IRestartCommand command)
        {
            this.view = view;
            restart = command;
        }

        public void present(Shell shell)
        {
            this.shell = shell;
        }

        public void notify(UnhandledErrorOccurred message)
        {
            view.attach_to(this);
            view.display(message.error);
            view.show_dialog(shell);
        }

        public void restart_application()
        {
            restart.run();
        }

        public Action close { get; set; }
    }
}