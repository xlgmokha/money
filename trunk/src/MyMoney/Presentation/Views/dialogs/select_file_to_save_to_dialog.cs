using System.Windows.Forms;
using MyMoney.Presentation.Model.Projects;

namespace MyMoney.Presentation.Views.dialogs
{
    public interface ISelectFileToSaveToDialog
    {
        IFile tell_me_the_path_to_the_file();
    }

    public class select_file_to_save_to_dialog : ISelectFileToSaveToDialog
    {
        private readonly FileDialog dialog;

        public select_file_to_save_to_dialog()
        {
            dialog = new SaveFileDialog {Filter = "My Money Files (*.mo)|*.mo"};
        }

        public IFile tell_me_the_path_to_the_file()
        {
            var result = dialog.ShowDialog();
            var the_path = (file) (result == DialogResult.Cancel ? string.Empty : dialog.FileName);
            dialog.Dispose();
            return the_path;
        }
    }
}