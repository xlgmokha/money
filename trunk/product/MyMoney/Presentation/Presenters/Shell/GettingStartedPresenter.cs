using MyMoney.Infrastructure.eventing;
using MyMoney.Presentation.Core;
using MyMoney.Presentation.Model.messages;
using MyMoney.Presentation.Views.Shell;

namespace MyMoney.Presentation.Presenters.Shell
{
    public interface IGettingStartedPresenter : IPresentationModule, IEventSubscriber<new_project_opened>
    {
    }

    public class GettingStartedPresenter : IGettingStartedPresenter
    {
        readonly IGettingStartedView view;
        readonly IEventAggregator broker;

        public GettingStartedPresenter(IGettingStartedView view, IEventAggregator broker)
        {
            this.view = view;
            this.broker = broker;
        }

        public void run()
        {
            broker.subscribe_to(this);
        }

        public void notify(new_project_opened message)
        {
            view.display();
        }
    }
}