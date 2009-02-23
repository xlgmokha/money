using System.Windows.Forms;
using MyMoney.Presentation.Model.Navigation;
using MyMoney.Presentation.Resources;
using MyMoney.Presentation.Views.Shell;
using MyMoney.Utility.Extensions;
using WeifenLuo.WinFormsUI.Docking;

namespace MyMoney.Presentation.Views.Navigation
{
    public partial class navigation_view : DockContent, INavigationView
    {
        private readonly IShell shell;

        public navigation_view(IShell shell)
        {
            InitializeComponent();
            this.shell = shell;
            initialize_the_ui();
        }

        private void initialize_the_ui()
        {
            uxNavigationTreeView.ImageList = new ImageList();
            ApplicationIcons.all().each(x => uxNavigationTreeView.ImageList.Images.Add(x.name_of_the_icon, x));
            CloseButton = false;
            Icon = ApplicationIcons.FileExplorer;
        }

        public void accept(INavigationTreeVisitor tree_view_visitor)
        {
            uxNavigationTreeView.Nodes.Clear();
            tree_view_visitor.visit(uxNavigationTreeView);
            shell.add(this);
            DockState = DockState.DockLeft;
        }
    }
}