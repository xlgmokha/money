using System;
using Gorilla.Commons.Utility;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Views;
using MoMoney.Presentation.Winforms.Resources;
using MoMoney.Service.Infrastructure.Eventing;
using MoMoney.Service.Infrastructure.Threading;

namespace MoMoney.Presentation.Presenters
{
    public interface IStatusBarPresenter : IModule,
                                           IEventSubscriber<SavedChangesEvent>,
                                           IEventSubscriber<NewProjectOpened>,
                                           IEventSubscriber<ClosingTheApplication>,
                                           IEventSubscriber<UnsavedChangesEvent>,
                                           IEventSubscriber<StartedRunningCommand>,
                                           IEventSubscriber<FinishedRunningCommand>,
                                           IEventSubscriber<ClosingProjectEvent>
    {
    }

    public class StatusBarPresenter : IStatusBarPresenter
    {
        readonly IStatusBarView view;
        readonly IEventAggregator broker;
        readonly ITimer timer;

        public StatusBarPresenter(IStatusBarView view, IEventAggregator broker, ITimer timer)
        {
            this.view = view;
            this.broker = broker;
            this.timer = timer;
        }

        public void run()
        {
            broker.subscribe(this);
            view.display(ApplicationIcons.blue_circle, "...");
        }

        public void notify(SavedChangesEvent message)
        {
            view.display(ApplicationIcons.floppy_disk, "Last Saved: {0}".formatted_using(Clock.now()));
        }

        public void notify(NewProjectOpened message)
        {
            view.display(ApplicationIcons.green_circle, "Ready");
        }

        public void notify(ClosingTheApplication message)
        {
            view.display(ApplicationIcons.hour_glass, "Good Bye!");
        }

        public void notify(ClosingProjectEvent message)
        {
            view.display(ApplicationIcons.grey_circle, "Closed");
        }

        public void notify(UnsavedChangesEvent message)
        {
            view.display(ApplicationIcons.red_circle, "Don't forget to save your work...");
        }

        public void notify(StartedRunningCommand message)
        {
            view.display(ApplicationIcons.hour_glass, "Running... {0}".formatted_using(message.running_action));
            timer.start_notifying(view, new TimeSpan(1));
        }

        public void notify(FinishedRunningCommand message)
        {
            view.display(ApplicationIcons.green_circle, "Finished... {0}".formatted_using(message.completed_action));
            timer.stop_notifying(view);
            view.reset_progress_bar();
        }
    }
}