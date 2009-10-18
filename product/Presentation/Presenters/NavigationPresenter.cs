using MoMoney.Presentation.Core;
using MoMoney.Presentation.Model.Navigation;
using MoMoney.Presentation.Views;

namespace MoMoney.Presentation.Presenters
{
    public interface INavigationPresenter : IContentPresenter
    {
    }

    public class NavigationPresenter : ContentPresenter<INavigationView>, INavigationPresenter
    {
        readonly INavigationTreeVisitor tree_view_visitor;

        public NavigationPresenter(INavigationView view, INavigationTreeVisitor tree_view_visitor) : base(view)
        {
            this.tree_view_visitor = tree_view_visitor;
        }

        public override void run()
        {
            view.accept(tree_view_visitor);
        }
    }
}