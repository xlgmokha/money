using MoMoney.Infrastructure.eventing;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Views.Shell;

namespace MoMoney.Presentation.Presenters.Shell
{
    public interface IApplicationShellPresenter : IPresentationModule, IEventSubscriber<new_project_opened>,
                                                  IEventSubscriber<closing_project_event>
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
            broker.subscribe_to<new_project_opened>(this);
            broker.subscribe_to<closing_project_event>(this);
        }

        public void notify(new_project_opened message)
        {
            //shell.clear_menu_items();
            //shell.close_all_windows();
        }

        public void notify(closing_project_event message)
        {
            shell.close_all_windows();
        }
    }
}