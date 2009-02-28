using MyMoney.Presentation.Model.Navigation;
using MyMoney.Presentation.Views.core;

namespace MyMoney.Presentation.Views.Navigation
{
    public interface INavigationView : IDockedContentView
    {
        void accept(INavigationTreeVisitor tree_view_visitor);
    }
}