using MoMoney.Presentation.Views.core;

namespace MoMoney.Presentation.Views.Shell
{
    public partial class LogFileView : ApplicationDockedWindow, ILogFileView
    {
        public LogFileView()
        {
            InitializeComponent();
        }

        public void display(string contents)
        {
            ux_log_file.Text = contents;
        }
    }
}