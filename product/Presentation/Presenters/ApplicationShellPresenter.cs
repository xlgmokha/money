using MoMoney.Presentation.Core;
using momoney.presentation.model.eventing;
using momoney.presentation.model.menu.file;
using MoMoney.Presentation.Views;
using MoMoney.Service.Infrastructure.Eventing;

namespace momoney.presentation.presenters
{
    public class ApplicationShellPresenter : IPresenter, IEventSubscriber<ClosingProjectEvent>
    {
         IShell shell;
         IEventAggregator broker;
         IExitCommand command;

        protected ApplicationShellPresenter()
        {
        }

        public ApplicationShellPresenter(IEventAggregator broker, IShell shell, IExitCommand command)
        {
            this.broker = broker;
            this.command = command;
            this.shell = shell;
        }

        public virtual void present(IShell shell1)
        {
            broker.subscribe(this);
        }

        public virtual void notify(ClosingProjectEvent message)
        {
            shell.close_all_windows();
        }

        public virtual void shut_down()
        {
            command.run();
        }
    }
}