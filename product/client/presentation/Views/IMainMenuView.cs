using momoney.presentation.presenters;
using momoney.presentation.views;

namespace MoMoney.Presentation.Views
{
    public interface IMainMenuView : IDockedContentView
    {
        void add(IActionTaskPaneFactory factory);
    }
}