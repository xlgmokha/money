using MoMoney.Presentation.Core;
using MoMoney.Presentation.Model.Navigation;
using MoMoney.Presentation.Views.core;
using MoMoney.Presentation.Views.Navigation;

namespace MoMoney.Presentation.Presenters.Navigation
{
    public interface INavigationPresenter : IContentPresenter
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

        IDockedContentView IContentPresenter.View
        {
            get { return view; }
        }
    }
}