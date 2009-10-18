using System.Windows.Forms;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.Presentation.Model.Navigation;
using MoMoney.Presentation.Views;
using MoMoney.Presentation.Winforms.Resources;
using WeifenLuo.WinFormsUI.Docking;

namespace MoMoney.Presentation.Winforms.Views
{
    public partial class NavigationView : ApplicationDockedWindow, INavigationView
    {
        readonly IShell shell;

        public NavigationView(IShell shell)
        {
            InitializeComponent();
            this.shell = shell;
            icon(ApplicationIcons.FileExplorer).docked_to(DockState.DockRightAutoHide);
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