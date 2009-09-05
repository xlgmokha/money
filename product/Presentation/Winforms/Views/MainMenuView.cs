using Gorilla.Commons.Windows.Forms.Helpers;
using MoMoney.Presentation.Presenters.Navigation;
using MoMoney.Presentation.Resources;
using MoMoney.Presentation.Views.core;
using WeifenLuo.WinFormsUI.Docking;

namespace MoMoney.Presentation.Views.Navigation
{
    public partial class MainMenuView : ApplicationDockedWindow, IMainMenuView
    {
        public MainMenuView()
        {
            InitializeComponent();

            titled("Main Menu")
                .icon(ApplicationIcons.FileExplorer)
                .cannot_be_closed()
                .docked_to(DockState.DockLeft);

            ux_system_task_pane.UseClassicTheme();
        }

        public void add(IActionTaskPaneFactory factory)
        {
            using (ux_system_task_pane.suspend_layout()) ux_system_task_pane.Expandos.Add(factory.create());
        }
    }
}