using MoMoney.Presentation.Model.Navigation;
using momoney.presentation.presenters;

namespace momoney.presentation.views
{
    public interface INavigationView : IDockedContentView, View<NavigationPresenter>
    {
        void accept(INavigationTreeVisitor tree_view_visitor);
    }
}