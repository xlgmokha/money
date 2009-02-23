using MyMoney.Presentation.Resources;

namespace MyMoney.Presentation.Views.Shell
{
    public interface IStatusBarView
    {
        void Display(HybridIcon icon_to_display, string text_to_display);
    }

    public class StatusBarView : IStatusBarView
    {
        private readonly IShell shell;

        public StatusBarView(IShell shell)
        {
            this.shell = shell;
        }

        public void Display(HybridIcon icon_to_display, string text_to_display)
        {
            shell.status_bar().Items.Clear();
            shell.status_bar().Items.Add(icon_to_display);
            shell.status_bar().Items.Add(text_to_display);
        }
    }
}