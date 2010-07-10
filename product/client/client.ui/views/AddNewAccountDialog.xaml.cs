using System.Windows;
using presentation.windows.presenters;

namespace presentation.windows.views
{
    public partial class AddNewAccountDialog : Dialog<AddNewAccountPresenter>
    {
        public AddNewAccountDialog()
        {
            InitializeComponent();
        }

        public void open()
        {
            Owner = Application.Current.MainWindow;
            ShowDialog();
        }
    }
}