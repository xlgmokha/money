using MoMoney.Presentation.Resources;

namespace MoMoney.Presentation.Views.Shell
{
    public interface IStatusBarView
    {
        void display(HybridIcon icon_to_display, string text_to_display);
    }
}