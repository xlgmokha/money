using System.Windows;
using presentation.windows.presenters;

namespace presentation.windows.views
{
    public partial class AddFamilyMemberDialog : Dialog<AddFamilyMemberPresenter>
    {
        public AddFamilyMemberDialog()
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