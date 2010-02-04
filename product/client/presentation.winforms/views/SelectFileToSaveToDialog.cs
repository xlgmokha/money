using System.Windows.Forms;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Infrastructure.FileSystem;
using momoney.presentation.views;

namespace MoMoney.Presentation.Winforms.Views
{
    public class SelectFileToSaveToDialog : ISelectFileToSaveToDialog
    {
        public File tell_me_the_path_to_the_file()
        {
            using (var dialog = new SaveFileDialog {Filter = "My Money Files (*.mo)|*.mo"})
            {
                return (ApplicationFile) (dialog.ShowDialog(Resolve.the<IWin32Window>()) == DialogResult.Cancel ? string.Empty : dialog.FileName);
            }
        }
    }
}