using System.Windows.Forms;
using MyMoney.Presentation.Model.Navigation;
using MyMoney.Presentation.Resources;
using MyMoney.Presentation.Views.core;
using MyMoney.Presentation.Views.Shell;
using MyMoney.Utility.Extensions;
using WeifenLuo.WinFormsUI.Docking;

namespace MyMoney.Presentation.Views.Navigation
{
    public partial class navigation_view : ApplicationDockedWindow, INavigationView
    {
        readonly IShell shell;

        public navigation_view(IShell shell)
        {
            InitializeComponent();
            this.shell = shell;
            initialize_the_ui();
        }

        void initialize_the_ui()
        {
            icon(ApplicationIcons.FileExplorer)
                .cannot_be_closed()
                .docked_to(DockState.DockLeft);

            uxNavigationTreeView.ImageList = new ImageList();
            ApplicationIcons.all().each(x => uxNavigationTreeView.ImageList.Images.Add(x.name_of_the_icon, x));
        }

        public void accept(INavigationTreeVisitor tree_view_visitor)
        {
            uxNavigationTreeView.Nodes.Clear();
            tree_view_visitor.visit(uxNavigationTreeView);
            shell.add(this);
        }
    }
}