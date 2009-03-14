using MoMoney.Domain.Core;
using MoMoney.Infrastructure.eventing;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Resources;
using MoMoney.Presentation.Views.Shell;
using MoMoney.Utility.Extensions;

namespace MoMoney.Presentation.Presenters.Shell
{
    public interface IStatusBarPresenter : IPresentationModule,
                                           IEventSubscriber<saved_changes_event>,
                                           IEventSubscriber<new_project_opened>,
                                           IEventSubscriber<closing_the_application>,
                                           IEventSubscriber<closing_project_event>
    {
    }

    public class StatusBarPresenter : IStatusBarPresenter
    {
        readonly IStatusBarView view;
        readonly IEventAggregator broker;

        public StatusBarPresenter(IStatusBarView view, IEventAggregator broker)
        {
            this.view = view;
            this.broker = broker;
        }

        public void run()
        {
            broker.subscribe_to<saved_changes_event>(this);
            broker.subscribe_to<new_project_opened>(this);
            broker.subscribe_to<closing_the_application>(this);
            broker.subscribe_to<closing_project_event>(this);
        }

        public void notify(saved_changes_event message)
        {
            view.display(ApplicationIcons.ApplicationReady, "Last Saved: {0}".formatted_using(Clock.now()));
        }

        public void notify(new_project_opened message)
        {
            view.display(ApplicationIcons.ApplicationReady, "Ready");
        }

        public void notify(closing_the_application message)
        {
            view.display(ApplicationIcons.Empty, "Good Bye!");
        }

        public void notify(closing_project_event message)
        {
            view.display(ApplicationIcons.ApplicationReady, "Ready");
        }
    }
}