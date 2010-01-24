using MoMoney.Presentation.Core;
using MoMoney.Presentation.Model.Navigation;
using momoney.presentation.views;

namespace momoney.presentation.presenters
{
    public class NavigationPresenter : ContentPresenter<INavigationView>
    {
        readonly INavigationTreeVisitor tree_view_visitor;

        public NavigationPresenter(INavigationView view, INavigationTreeVisitor tree_view_visitor) : base(view)
        {
            this.tree_view_visitor = tree_view_visitor;
        }

        public override void present()
        {
            view.accept(tree_view_visitor);
        }
    }
}