using MyMoney.Presentation.Core;
using MyMoney.Presentation.Model.Navigation;
using MyMoney.Presentation.Views.Navigation;

namespace MyMoney.Presentation.Presenters.Navigation
{
    public interface INavigationPresenter : IPresentationModule
    {
    }

    public class NavigationPresenter : INavigationPresenter
    {
        readonly INavigationView view;
        readonly INavigationTreeVisitor tree_view_visitor;

        public NavigationPresenter(INavigationView view, INavigationTreeVisitor tree_view_visitor)
        {
            this.view = view;
            this.tree_view_visitor = tree_view_visitor;
        }

        public void run()
        {
            view.accept(tree_view_visitor);
        }
    }
}