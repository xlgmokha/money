using System.Windows.Forms;

namespace MoMoney.Presentation.Views.Shell
{
    public interface ITitleBar
    {
        void display(string title);
        void append_asterik();
        void remove_asterik();
    }

    public class TitleBar : ITitleBar
    {
        readonly IShell shell;

        public TitleBar(IShell shell)
        {
            this.shell = shell;
        }

        public void display(string title)
        {
            shell.region<Form>(x =>
            {
                if (x.Text.Contains("-"))
                {
                   x.Text =x.Text.Remove(x.Text.IndexOf("-") - 1);
                }
               x.Text =x.Text + " - " + title;
            });
        }

        public void append_asterik()
        {
            shell.region<Form>(x =>
            {
                if (x.Text.Contains("*"))
                {
                    return;
                }
                x.Text = x.Text + "*";
            });
        }

        public void remove_asterik()
        {
            shell.region<Form>(x =>
            {
                x.Text = x.Text.Replace("*", "");
            });
        }
    }
}