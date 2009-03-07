using Castle.Core;
using MoMoney.Infrastructure.interceptors;
using MoMoney.Presentation.Resources;
using MoMoney.Presentation.Views.core;
using MoMoney.Presentation.Views.Shell;
using WeifenLuo.WinFormsUI.Docking;
using XPExplorerBar;

namespace MoMoney.Presentation.Views.Navigation
{
    [Interceptor(typeof (ISynchronizedInterceptor))]
    public partial class MainMenuView : ApplicationDockedWindow, IMainMenuView
    {
        readonly IShell shell;

        public MainMenuView(IShell shell)
        {
            InitializeComponent();
            this.shell = shell;

            titled("Main Menu")
                .icon(ApplicationIcons.FileExplorer)
                .cannot_be_closed()
                .docked_to(DockState.DockLeft);

            ux_system_task_pane.UseClassicTheme();
        }

        public void add(Expando expando)
        {
            ux_system_task_pane.Expandos.Add(expando);
        }

        public void display()
        {
            shell.add(this);
        }
    }
}