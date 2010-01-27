using MoMoney.Presentation.Core;
using MoMoney.Presentation.Model.Navigation;
using momoney.presentation.views;

namespace momoney.presentation.presenters
{
    public class NavigationPresenter : TabPresenter<INavigationView>
    {
        readonly INavigationTreeVisitor tree_view_visitor;

        public NavigationPresenter(INavigationView view, INavigationTreeVisitor tree_view_visitor) : base(view)
        {
            this.tree_view_visitor = tree_view_visitor;
        }

        protected override void present()
        {
            view.accept(tree_view_visitor);
        }
    }
}