using MoMoney.Presentation.Model.Navigation;
using MoMoney.Presentation.Views.Core;

namespace MoMoney.Presentation.Views.Navigation
{
    public interface INavigationView : IDockedContentView
    {
        void accept(INavigationTreeVisitor tree_view_visitor);
    }
}