using gorilla.commons.utility;
using MoMoney.Presentation;
using momoney.presentation.model.eventing;
using momoney.presentation.views;
using MoMoney.Service.Infrastructure.Eventing;

namespace momoney.presentation.presenters
{
    public interface ITaskTrayPresenter : IModule,
                                          IEventSubscriber<SavedChangesEvent>,
                                          IEventSubscriber<StartedRunningCommand>,
                                          IEventSubscriber<FinishedRunningCommand>,
                                          IEventSubscriber<NewProjectOpened>
    {
    }

    public class TaskTrayPresenter : ITaskTrayPresenter
    {
        readonly ITaskTrayMessageView view;
        readonly IEventAggregator broker;

        public TaskTrayPresenter(ITaskTrayMessageView view, IEventAggregator broker)
        {
            this.view = view;
            this.broker = broker;
        }

        public void run()
        {
            view.display("Welcome!");
            view.display("Visit http://mokhan.ca for more information!");
            broker.subscribe_to<SavedChangesEvent>(this);
            broker.subscribe_to<NewProjectOpened>(this);
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