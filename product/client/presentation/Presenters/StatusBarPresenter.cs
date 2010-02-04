using System;
using gorilla.commons.utility;
using Gorilla.Commons.Utility;
using MoMoney.Presentation.Core;
using momoney.presentation.model.eventing;
using momoney.presentation.resources;
using momoney.presentation.views;
using MoMoney.Presentation.Views;
using MoMoney.Service.Infrastructure.Eventing;
using MoMoney.Service.Infrastructure.Threading;

namespace momoney.presentation.presenters
{
    public class StatusBarPresenter :
        Presenter,
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

        public StatusBarPresenter(IStatusBarView view, ITimer timer)
        {
            this.view = view;
            this.timer = timer;
        }

        public IRegionManager shell { get; set; }

        public void present(Shell shell)
        {
            this.shell = shell;
            view.attach_to(this);
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