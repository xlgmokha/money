using momoney.presentation.views;
using MoMoney.Presentation.Winforms.Resources;

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
            titled("Log File - {0}", file_path)
                .icon(ApplicationIcons.ViewLog);
        }

        public void run(string file_contents)
        {
            ux_log_file.Text = file_contents;
        }
    }
}