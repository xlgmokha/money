using momoney.presentation.presenters;
using MoMoney.Presentation.Presenters;
using momoney.presentation.views;

namespace MoMoney.Presentation.Views
{
    public interface IMainMenuView : ITab, View<MainMenuPresenter>
    {
        void add(IActionTaskPaneFactory factory);
    }
}