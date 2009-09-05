using Gorilla.Commons.Infrastructure.Eventing;
using Gorilla.Commons.Utility;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Views.Shell;
using MoMoney.Presentation.Winforms.Resources;

namespace MoMoney.Presentation.Presenters.Shell
{
    public interface IStatusBarPresenter : IModule,
                                           IEventSubscriber<SavedChangesEvent>,
                                           IEventSubscriber<NewProjectOpened>,
                                           IEventSubscriber<ClosingTheApplication>,
                                           IEventSubscriber<ClosingProjectEvent>
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
            broker.subscribe(this);
        }

        public void notify(SavedChangesEvent message)
        {
            view.display(ApplicationIcons.ApplicationReady, "Last Saved: {0}".formatted_using(Clock.now()));
        }

        public void notify(NewProjectOpened message)
        {
            view.display(ApplicationIcons.ApplicationReady, "Ready");
        }

        public void notify(ClosingTheApplication message)
        {
            view.display(ApplicationIcons.Empty, "Good Bye!");
        }

        public void notify(ClosingProjectEvent message)
        {
            view.display(ApplicationIcons.ApplicationReady, "Ready");
        }
    }
}