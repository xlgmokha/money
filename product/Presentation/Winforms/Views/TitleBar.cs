using System.Windows.Forms;
using MoMoney.Presentation.Views;

namespace MoMoney.Presentation.Winforms.Views
{
    public class TitleBar : ITitleBar
    {
        readonly IRegionManager shell;

        public TitleBar(IRegionManager shell)
        {
            this.shell = shell;
        }

        public void display(string title)
        {
            shell.region<Form>(x =>
                                   {
                                       if (x.Text.Contains("-")) x.Text = x.Text.Remove(x.Text.IndexOf("-") - 1);
                                       x.Text = x.Text + " - " + title;
                                   });
        }

        public void append_asterik()
        {
            shell.region<Form>(x =>
                                   {
                                       if (x.Text.Contains("*")) return;
                                       x.Text = x.Text + "*";
                                   });
        }

        public void remove_asterik()
        {
            shell.region<Form>(x => { x.Text = x.Text.Replace("*", ""); });
        }
    }
}