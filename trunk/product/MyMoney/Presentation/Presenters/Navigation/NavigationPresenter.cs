using MoMoney.Infrastructure.eventing;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Model.Navigation;
using MoMoney.Presentation.Views.Navigation;

namespace MoMoney.Presentation.Presenters.Navigation
{
    public interface INavigationPresenter : IPresentationModule, IEventSubscriber<new_project_opened>
    {
    }

    public class NavigationPresenter : INavigationPresenter
    {
        readonly INavigationView view;
        readonly INavigationTreeVisitor tree_view_visitor;
        IEventAggregator broker;

        public NavigationPresenter(INavigationView view, INavigationTreeVisitor tree_view_visitor,
                                   IEventAggregator broker)
        {
            this.view = view;
            this.broker = broker;
            this.tree_view_visitor = tree_view_visitor;
        }

        public void run()
        {
            broker.subscribe_to(this);
        }

        public void notify(new_project_opened message)
        {
            view.accept(tree_view_visitor);
        }
    }
}