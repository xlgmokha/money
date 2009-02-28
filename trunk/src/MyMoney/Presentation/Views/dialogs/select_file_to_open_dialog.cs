using System.Windows.Forms;
using MyMoney.Presentation.Model.Projects;

namespace MyMoney.Presentation.Views.dialogs
{
    public interface ISelectFileToOpenDialog
    {
        IFile tell_me_the_path_to_the_file();
    }

    public class select_file_to_open_dialog : ISelectFileToOpenDialog
    {
        private readonly FileDialog dialog;

        public select_file_to_open_dialog()
        {
            dialog = new OpenFileDialog {Filter = "My Money Files (*.mo)|*.mo"};
        }

        public IFile tell_me_the_path_to_the_file()
        {
            var result = dialog.ShowDialog();
            var path_to_the_file = (ApplicationFile) (result.Equals(DialogResult.Cancel) ? string.Empty : dialog.FileName);
            dialog.Dispose();
            return path_to_the_file;
        }
    }
}