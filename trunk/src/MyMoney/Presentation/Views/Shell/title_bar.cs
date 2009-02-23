namespace MyMoney.Presentation.Views.Shell
{
    public interface ITitleBar
    {
        void display(string title);
        void append_asterik();
        void remove_asterik();
    }

    public class title_bar : ITitleBar
    {
        private readonly IShell shell;

        public title_bar(IShell shell)
        {
            this.shell = shell;
        }

        public void display(string title)
        {
            if (shell.Text.Contains("-")) {
                shell.Text = shell.Text.Remove(shell.Text.IndexOf("-") - 1);
            }
            shell.Text = shell.Text + " - " + title;
        }

        public void append_asterik()
        {
            if (shell.Text.Contains("*")) {
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