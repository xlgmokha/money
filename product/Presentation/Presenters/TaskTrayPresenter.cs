using Gorilla.Commons.Infrastructure.Eventing;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Views.Shell;

namespace MoMoney.Presentation.Presenters.Shell
{
    public interface ITaskTrayPresenter : IModule,
                                          IEventSubscriber<SavedChangesEvent>,
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
    }
}