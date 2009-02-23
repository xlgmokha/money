using MyMoney.Presentation.Core;
using MyMoney.Presentation.Model.Navigation;
using MyMoney.Presentation.Views.Navigation;

namespace MyMoney.Presentation.Presenters.Navigation
{
    //public interface INavigationPresenter : IApplicationShellPresenter
    public interface INavigationPresenter : IPresenter
    {
    }

    public class navigation_presenter : INavigationPresenter
    {
        private readonly INavigationView view;
        private readonly INavigationTreeVisitor tree_view_visitor;

        public navigation_presenter(INavigationView view, INavigationTreeVisitor tree_view_visitor)
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