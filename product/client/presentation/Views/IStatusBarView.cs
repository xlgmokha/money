using MoMoney.Presentation.Winforms.Resources;
using momoney.service.infrastructure.threading;

namespace MoMoney.Presentation.Views
{
    public interface IStatusBarView : ITimerClient
    {
        void display(HybridIcon icon_to_display, string text_to_display);
        void reset_progress_bar();
    }
}