using System;
using gorilla.commons.utility;
using Gorilla.Commons.Utility;
using MoMoney.Presentation;
using momoney.presentation.model.eventing;
using MoMoney.Presentation.Views;
using MoMoney.Presentation.Winforms.Resources;
using MoMoney.Service.Infrastructure.Eventing;
using MoMoney.Service.Infrastructure.Threading;

namespace momoney.modules
{
    public class StatusBarModule :
        IModule,
        EventSubscriber<SavedChangesEvent>,
        EventSubscriber<NewProjectOpened>,
        EventSubscriber<ClosingTheApplication>,
        EventSubscriber<UnsavedChangesEvent>,
        EventSubscriber<StartedRunningCommand>,
        EventSubscriber<FinishedRunningCommand>,
        EventSubscriber<ClosingProjectEvent>
    {
        readonly IStatusBarView view;
        readonly ITimer timer;

        public StatusBarModule(IStatusBarView view, ITimer timer)
        {
            this.view = view;
            this.timer = timer;
        }

        public void run()
        {
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
            timer.start_notifying(view, new TimeSpan(1));
        }

        public void notify(FinishedRunningCommand message)
        {
            timer.stop_notifying(view);
            view.reset_progress_bar();
        }
    }
}