using System;
using MoMoney.Presentation.Core;
using momoney.presentation.model.eventing;
using momoney.presentation.model.menu.file;
using MoMoney.Presentation.Views;
using MoMoney.Service.Infrastructure.Eventing;

namespace momoney.presentation.presenters
{
    public class ApplicationShellPresenter : IPresenter, IEventSubscriber<ClosingProjectEvent>
    {
        IExitCommand command;

        Action shutdown = () =>
                          {
                          };

        protected ApplicationShellPresenter()
        {
        }

        public ApplicationShellPresenter(IExitCommand command)
        {
            this.command = command;
        }

        public virtual void present(IShell shell)
        {
            shutdown = () =>
                       {
                           shell.close_all_windows();
                       };
        }

        public virtual void notify(ClosingProjectEvent message)
        {
            shutdown();
        }

        public virtual void shut_down()
        {
            command.run();
        }
    }
}