using MoMoney.Presentation.Presenters.Navigation;
using MoMoney.Presentation.Views.Core;

namespace MoMoney.Presentation.Views.Navigation
{
    public interface IMainMenuView : IDockedContentView
    {
        void add(IActionTaskPaneFactory factory);
    }
}