using Castle.Core;
using MyMoney.Infrastructure.eventing;
using MyMoney.Presentation.Core;
using MyMoney.Presentation.Model.messages;
using MyMoney.Presentation.Views.Shell;

namespace MyMoney.Presentation.Presenters.Shell
{
    public interface ITaskTrayPresenter : IPresentationModule,
                                          IEventSubscriber<saved_changes_event>,
                                          IEventSubscriber<new_project_opened>
    {
    }

    [Singleton]
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
            broker.subscribe_to<saved_changes_event>(this);
            broker.subscribe_to<new_project_opened>(this);
        }

        public void notify(saved_changes_event message)
        {
            view.display("successfully saved changes");
        }

        public void notify(new_project_opened message)
        {
            view.display("opened {0}", message.path);
        }
    }
}