using MyMoney.Domain.Core;
using MyMoney.Infrastructure.eventing;
using MyMoney.Presentation.Core;
using MyMoney.Presentation.Model.messages;
using MyMoney.Presentation.Resources;
using MyMoney.Presentation.Views.Shell;
using MyMoney.Utility.Extensions;

namespace MyMoney.Presentation.Presenters.Shell
{
    public interface IStatusBarPresenter : IPresentationModule,
                                           IEventSubscriber<saved_changes_event>,
                                           IEventSubscriber<new_project_opened>,
                                           IEventSubscriber<closing_the_application>
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
    }
}