using MoMoney.Infrastructure.Extensions;

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
            if (shell.Text.Contains("-"))
            {
                shell.Text = shell.Text.Remove(shell.Text.IndexOf("-") - 1);
            }
            shell.Text = shell.Text + " - " + title;
            this.log().debug("displaying title: {0}", title);
        }

        public void append_asterik()
        {
            if (shell.Text.Contains("*"))
            {
                return;
            }
            shell.Text = shell.Text + "*";
        }

        public void remove_asterik()
        {
            shell.Text = shell.Text.Replace("*", "");
        }
    }
}