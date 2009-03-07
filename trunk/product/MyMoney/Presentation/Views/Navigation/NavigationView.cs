using System.Windows.Forms;
using Castle.Core;
using MoMoney.Infrastructure.interceptors;
using MoMoney.Presentation.Model.Navigation;
using MoMoney.Presentation.Resources;
using MoMoney.Presentation.Views.core;
using MoMoney.Presentation.Views.Shell;
using MoMoney.Utility.Extensions;
using WeifenLuo.WinFormsUI.Docking;

namespace MoMoney.Presentation.Views.Navigation
{
    [Interceptor(typeof (ISynchronizedInterceptor))]
    public partial class NavigationView : ApplicationDockedWindow, INavigationView
    {
        readonly IShell shell;

        public NavigationView(IShell shell)
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