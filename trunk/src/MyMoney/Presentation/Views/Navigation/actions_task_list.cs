using MyMoney.Presentation.Presenters.Commands;
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

    public partial class actions_task_list : DockContent, IActionsTaskView
    {
        readonly IShell shell;

        public actions_task_list(IShell shell)
        {
            InitializeComponent();
            CloseButton = false;
            CloseButtonVisible = false;
            this.shell = shell;

            initialize_the_ui();
        }

        void initialize_the_ui()
        {
            TabText = "Action Items";
            Icon = ApplicationIcons.FileExplorer;
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
            DockState = DockState.DockLeft;
        }
    }
}