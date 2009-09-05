using MoMoney.Presentation.Views.Shell;

namespace MoMoney.Presentation.Winforms.Views
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