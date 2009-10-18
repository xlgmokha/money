using MoMoney.Presentation.Presenters;

namespace MoMoney.Presentation.Views
{
    public interface IMainMenuView : IDockedContentView
    {
        void add(IActionTaskPaneFactory factory);
    }
}