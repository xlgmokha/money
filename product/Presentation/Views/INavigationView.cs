using MoMoney.Presentation.Model.Navigation;

namespace MoMoney.Presentation.Views
{
    public interface INavigationView : IDockedContentView
    {
        void accept(INavigationTreeVisitor tree_view_visitor);
    }
}