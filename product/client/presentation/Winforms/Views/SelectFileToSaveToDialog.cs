using System.Windows.Forms;
using Gorilla.Commons.Infrastructure.FileSystem;
using momoney.presentation.views;

namespace MoMoney.Presentation.Winforms.Views
{
    public class SelectFileToSaveToDialog : ISelectFileToSaveToDialog
    {
        readonly FileDialog dialog;
        readonly IWin32Window window;

        public SelectFileToSaveToDialog(IWin32Window window)
        {
            dialog = new SaveFileDialog {Filter = "My Money Files (*.mo)|*.mo"};
            this.window = window;
        }

        public File tell_me_the_path_to_the_file()
        {
            var result = dialog.ShowDialog(window);
            var the_path = (ApplicationFile) (result == DialogResult.Cancel ? string.Empty : dialog.FileName);
            dialog.Dispose();
            return the_path;
        }
    }
}