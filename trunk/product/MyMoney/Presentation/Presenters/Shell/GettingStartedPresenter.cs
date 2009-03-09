using JetBrains.Annotations;
using MoMoney.Infrastructure.eventing;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Views.Shell;

namespace MoMoney.Presentation.Presenters.Shell
{
    public interface IGettingStartedPresenter : IPresentationModule, IEventSubscriber<new_project_opened>
    {
    }

    [UsedImplicitly]
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
            view.display();
        }

        public void notify(new_project_opened message)
        {
            //view.display();
        }
    }
}