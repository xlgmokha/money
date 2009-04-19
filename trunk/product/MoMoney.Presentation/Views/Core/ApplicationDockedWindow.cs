using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Gorilla.Commons.Utility.Extensions;
using Gorilla.Commons.Windows.Forms;
using Gorilla.Commons.Windows.Forms.Helpers;
using Gorilla.Commons.Windows.Forms.Resources;
using MoMoney.Presentation.Resources;
using WeifenLuo.WinFormsUI.Docking;

namespace MoMoney.Presentation.Views.core
{
    public interface IApplicationDockedWindow : IWindowEvents, IDockedContentView
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

            on_activated = x => { };
            on_deactivate = x => { };
            on_closed = x => { };
            on_closing = x => { };
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            on_activated(e);
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            on_deactivate(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            on_closing(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            on_closed(e);
        }

        public ControlAction<EventArgs> on_activated { get; set; }
        public ControlAction<EventArgs> on_deactivate { get; set; }
        public ControlAction<EventArgs> on_closed { get; set; }
        public ControlAction<CancelEventArgs> on_closing { get; set; }

        public IApplicationDockedWindow create_tool_tip_for(string title, string caption, Control control)
        {
            var tip = new ToolTip {IsBalloon = true, ToolTipTitle = title};
            tip.SetToolTip(control, caption);
            control.Controls.Add(new ControlAdapter(tip));
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
                //else
                {
                    Show(panel, dock_state);
                }
            }
        }

        void remove_from(DockPanel panel)
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
    }
}