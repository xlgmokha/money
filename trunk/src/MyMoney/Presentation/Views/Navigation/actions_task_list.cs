using MyMoney.Presentation.Resources;
using MyMoney.Presentation.Views.core;
using MyMoney.Presentation.Views.Shell;
using WeifenLuo.WinFormsUI.Docking;
using XPExplorerBar;

namespace MyMoney.Presentation.Views.Navigation
{
    public interface IActionsTaskView : IDockedContentView
    {
        void display();
        void add(Expando expando);
    }

    public partial class actions_task_list : ApplicationDockedWindow, IActionsTaskView
    {
        readonly IShell shell;

        public actions_task_list(IShell shell)
        {
            InitializeComponent();
            this.shell = shell;

            initialize_the_ui();
        }

        void initialize_the_ui()
        {
            titled("Actions Items")
                .icon(ApplicationIcons.FileExplorer)
                .cannot_be_closed()
                .docked_to(DockState.DockLeft);

            ux_system_task_pane.UseClassicTheme();
            //ux_system_task_pane.UseCustomTheme(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "itunes.dat"));
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