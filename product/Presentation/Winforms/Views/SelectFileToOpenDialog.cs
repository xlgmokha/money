using System.Windows.Forms;
using Gorilla.Commons.Infrastructure.FileSystem;
using MoMoney.Presentation.Views;

namespace MoMoney.Presentation.Winforms.Views
{
    public class SelectFileToOpenDialog : ISelectFileToOpenDialog
    {
        readonly IWin32Window window;
        readonly FileDialog dialog;

        public SelectFileToOpenDialog(IWin32Window window)
        {
            this.window = window;
            dialog = new OpenFileDialog {Filter = "My Money Files (*.mo)|*.mo"};
        }

        public IFile tell_me_the_path_to_the_file()
        {
            var result = dialog.ShowDialog(window);
            var path_to_the_file =
                (ApplicationFile) (result.Equals(DialogResult.Cancel) ? string.Empty : dialog.FileName);
            dialog.Dispose();
            return path_to_the_file;
        }
    }
}