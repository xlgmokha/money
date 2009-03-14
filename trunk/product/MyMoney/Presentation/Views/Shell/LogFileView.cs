using MoMoney.Presentation.Views.core;

namespace MoMoney.Presentation.Views.Shell
{
    public partial class LogFileView : ApplicationDockedWindow, ILogFileView
    {
        public LogFileView()
        {
            InitializeComponent();
        }

        public void display(string file_path, string file_contents)
        {
            titled("Log File - {0}", file_path);
            ux_log_file.Text = file_contents;
        }
    }
}