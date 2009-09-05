using MoMoney.Presentation.Views.core;

namespace MoMoney.Presentation.Views.Shell
{
    public partial class LogFileView : ApplicationDockedWindow, ILogFileView
    {
        public LogFileView()
        {
            InitializeComponent();
        }

        public void display(string file_path)
        {
            titled("Log File - {0}", file_path);
        }

        public void run(string file_contents)
        {
            ux_log_file.Text = file_contents;
        }
    }
}