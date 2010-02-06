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

        public void show_dialog(Window parent)
        {
            Owner = parent;
            ShowDialog();
        }
    }
}