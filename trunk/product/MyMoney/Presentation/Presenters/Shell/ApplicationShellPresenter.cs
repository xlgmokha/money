using MoMoney.Infrastructure.eventing;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Model.Menu.File.Commands;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Views.Shell;

namespace MoMoney.Presentation.Presenters.Shell
{
    public interface IApplicationShellPresenter : IPresentationModule, IEventSubscriber<ClosingProjectEvent>
    {
        void shut_down();
    }

    public class ApplicationShellPresenter : IApplicationShellPresenter
    {
        readonly IShell shell;
        readonly IEventAggregator broker;
        readonly IExitCommand command;

        public ApplicationShellPresenter(IEventAggregator broker, IShell shell, IExitCommand command)
        {
            this.broker = broker;
            this.command = command;
            this.shell = shell;
        }

        public void run()
        {
            broker.subscribe(this);
            shell.attach_to(this);
        }

        public void notify(ClosingProjectEvent message)
        {
            shell.close_all_windows();
        }

        public void shut_down()
        {
            command.run();
        }
    }
}