using System.Windows.Forms;
using MoMoney.Presentation.Resources;

namespace MoMoney.Presentation.Views.Shell
{
    public class StatusBarView : IStatusBarView
    {
        readonly IShell shell;

        public StatusBarView(IShell shell)
        {
            this.shell = shell;
        }

        public void display(HybridIcon icon_to_display, string text_to_display)
        {
            //shell.region<StatusStrip>(x =>
            //                              {
            //                                  //x.Items.Clear();
            //                                  ToolStripItem item = x.Items.Add(icon_to_display);
            //                                  this.log().debug("icon_is:{0}", item);
            //                                  x.Items.Add(text_to_display);
            //                              });
            shell.region<ToolStripStatusLabel>(x =>
                                                   {
                                                       x.Text = text_to_display;
                                                       x.Image = icon_to_display;
                                                   });
        }
    }
}