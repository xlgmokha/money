using System.Windows;
using presentation.windows.presenters;

namespace presentation.windows.views
{
    public partial class AddNewDetailAccountDialog : Dialog<AddNewDetailAccountPresenter>
    {
        public AddNewDetailAccountDialog()
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