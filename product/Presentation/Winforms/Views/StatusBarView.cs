using System.Windows.Forms;
using MoMoney.Presentation.Views;
using MoMoney.Presentation.Views.Shell;
using MoMoney.Presentation.Winforms.Resources;

namespace MoMoney.Presentation.Winforms.Views
{
    public class StatusBarView : IStatusBarView
    {
        readonly IRegionManager shell;

        public StatusBarView(IRegionManager shell)
        {
            this.shell = shell;
        }

        public void display(HybridIcon icon_to_display, string text_to_display)
        {
            shell.region<ToolStripStatusLabel>(x =>
                                                   {
                                                       x.Text = text_to_display;
                                                       x.Image = icon_to_display;
                                                   });
        }

        public void reset_progress_bar()
        {
            shell.region<ToolStripProgressBar>(x => { x.ProgressBar.Value = 0; });
        }

        public void notify()
        {
            shell.region<ToolStripProgressBar>(x => { x.Increment(10); });
        }
    }
}