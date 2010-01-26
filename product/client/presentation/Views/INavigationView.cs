using MoMoney.Presentation.Model.Navigation;

namespace momoney.presentation.views
{
    public interface INavigationView : IDockedContentView
    {
        void accept(INavigationTreeVisitor tree_view_visitor);
    }
}