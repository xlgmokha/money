using MoMoney.Infrastructure.eventing;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Views.Shell;

namespace MoMoney.Presentation.Presenters.Shell
{
    public interface IApplicationShellPresenter : IPresentationModule, IEventSubscriber<NewProjectOpened>,
                                                  IEventSubscriber<ClosingProjectEvent>
    {
    }

    public class ApplicationShellPresenter : IApplicationShellPresenter
    {
        readonly IShell shell;
        readonly IEventAggregator broker;

        public ApplicationShellPresenter(IEventAggregator broker, IShell shell)
        {
            this.broker = broker;
            this.shell = shell;
        }

        public void run()
        {
            broker.subscribe_to<NewProjectOpened>(this);
            broker.subscribe_to<ClosingProjectEvent>(this);
        }

        public void notify(NewProjectOpened message)
        {
            //shell.clear_menu_items();
            //shell.close_all_windows();
        }

        public void notify(ClosingProjectEvent message)
        {
            shell.close_all_windows();
        }
    }
}