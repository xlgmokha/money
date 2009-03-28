using System;
using System.Linq;
using System.Windows.Forms;
using MoMoney.Presentation.Resources;
using MoMoney.Presentation.Views.helpers;
using MoMoney.Utility.Extensions;
using WeifenLuo.WinFormsUI.Docking;

namespace MoMoney.Presentation.Views.core
{
    public interface IApplicationDockedWindow : IDockedContentView
    {
        IApplicationDockedWindow create_tool_tip_for(string title, string caption, Control control);
        IApplicationDockedWindow titled(string title, params object[] arguments);
        IApplicationDockedWindow icon(ApplicationIcon icon);
        IApplicationDockedWindow cannot_be_closed();
        IApplicationDockedWindow docked_to(DockState state);
    }

    public partial class ApplicationDockedWindow : DockContent, IApplicationDockedWindow
    {
        DockState dock_state;

        public ApplicationDockedWindow()
        {
            InitializeComponent();
            Icon = ApplicationIcons.Application;
            dock_state = DockState.Document;
            HideOnClose = true;
        }

        public IApplicationDockedWindow create_tool_tip_for(string title, string caption, Control control)
        {
            new ToolTip {IsBalloon = true, ToolTipTitle = title}.SetToolTip(control, caption);
            return this;
        }

        public IApplicationDockedWindow titled(string title, params object[] arguments)
        {
            TabText = title.formatted_using(arguments);
            return this;
        }

        public IApplicationDockedWindow icon(ApplicationIcon icon)
        {
            Icon = icon;
            return this;
        }

        public IApplicationDockedWindow cannot_be_closed()
        {
            CloseButton = false;
            CloseButtonVisible = false;
            return this;
        }

        public IApplicationDockedWindow docked_to(DockState state)
        {
            dock_state = state;
            return this;
        }

        public void add_to(DockPanel panel)
        {
            using (new SuspendLayout(panel))
            {
                if (window_is_already_contained_in(panel)) remove_from(panel);
                Show(panel);
                DockState = dock_state;
            }
        }

        public void remove_from(DockPanel panel)
        {
            using (new SuspendLayout(panel))
            {
                var panel_to_remove = get_window_from(panel);
                panel_to_remove.DockHandler.Close();
                panel_to_remove.DockHandler.Dispose();
            }
        }

        IDockContent get_window_from(DockPanel panel)
        {
            return panel.Documents.Single(matches);
        }

        bool window_is_already_contained_in(DockPanel panel)
        {
            return panel.Documents.Count(matches) > 0;
        }

        bool matches(IDockContent x)
        {
            return x.DockHandler.TabText.Equals(TabText);
        }

        protected void on_ui_thread(Action action)
        {
            if (InvokeRequired)
            {
                BeginInvoke(action);
            }
            else
            {
                action();
            }
        }
    }
}