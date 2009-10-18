using System.ComponentModel;
using Gorilla.Commons.Infrastructure.Logging;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Views;
using MoMoney.Service.Infrastructure.Eventing;
using momoney.utility;

namespace MoMoney.Presentation.Presenters
{
    public interface ITaskTrayPresenter : IModule,
                                          IEventSubscriber<SavedChangesEvent>,
                                          IEventSubscriber<StartedRunningCommand>,
                                          IEventSubscriber<FinishedRunningCommand>,
                                          IEventSubscriber<NewProjectOpened> {}

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
            this.log().debug("running {0}", message.running_action);
            if (message.running_action.is_decorated_with<DisplayNameAttribute>())
            {
                var attribute = message.running_action.attribute<DisplayNameAttribute>();
                view.display("Running... {0}".formatted_using(attribute.DisplayName));
            }
            else
            {
                view.display("Running... {0}".formatted_using(message.running_action));
            }
        }

        public void notify(FinishedRunningCommand message)
        {
            view.display("Finished... {0}".formatted_using(message.completed_action));
        }
    }
}