using momoney.presentation.presenters;
using momoney.presentation.resources;
using momoney.presentation.views;
using momoney.service.infrastructure.threading;

namespace MoMoney.Presentation.Views
{
    public interface IStatusBarView : ITimerClient, View<StatusBarPresenter>
    {
        void display(HybridIcon icon_to_display, string text_to_display);
        void reset_progress_bar();
    }
}