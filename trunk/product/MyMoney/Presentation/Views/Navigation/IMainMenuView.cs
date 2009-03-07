using MoMoney.Presentation.Views.core;
using XPExplorerBar;

namespace MoMoney.Presentation.Views.Navigation
{
    public interface IMainMenuView : IDockedContentView
    {
        void display();
        void add(Expando expando);
    }
}