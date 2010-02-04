using gorilla.commons.utility;
using MoMoney.Presentation.Core;
using momoney.presentation.model.eventing;
using momoney.presentation.views;
using MoMoney.Service.Infrastructure.Eventing;

namespace momoney.presentation.presenters
{
    public class TaskTrayPresenter :
        Presenter,
        EventSubscriber<SavedChangesEvent>,
        EventSubscriber<StartedRunningCommand>,
        EventSubscriber<FinishedRunningCommand>,
        EventSubscriber<NewProjectOpened>
    {
        readonly ITaskTrayMessageView view;

        public TaskTrayPresenter(ITaskTrayMessageView view)
        {
            this.view = view;
        }

        public void present(Shell shell)
        {
            view.display("Welcome!");
            view.display("Visit http://mokhan.ca for more information!");
        }

        public void notify(SavedChangesEvent message)
        {
            view.display("successfully saved changes");
        }

        public void notify(NewProjectOpened message)
        {
            view.display("opened {0}", message.path);
        }

        public void notify(StartedRunningCommand message)
        {
            view.display("Running... {0}".formatted_using(message.running_action));
        }

        public void notify(FinishedRunningCommand message)
        {
            view.display("Finished... {0}".formatted_using(message.completed_action));
        }
    }
}