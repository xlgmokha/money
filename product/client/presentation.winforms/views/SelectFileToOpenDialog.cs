using System.Windows.Forms;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Infrastructure.FileSystem;
using momoney.presentation.views;

namespace MoMoney.Presentation.Winforms.Views
{
    public class SelectFileToOpenDialog : ISelectFileToOpenDialog
    {
        public File tell_me_the_path_to_the_file()
        {
            using (var dialog = new OpenFileDialog {Filter = "My Money Files (*.mo)|*.mo"})
            {
                var result = dialog.ShowDialog(Resolve.the<IWin32Window>());
                return (ApplicationFile) (result.Equals(DialogResult.Cancel) ? string.Empty : dialog.FileName);
            }
        }
    }
}