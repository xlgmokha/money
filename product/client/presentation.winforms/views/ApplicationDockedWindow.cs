using System.Windows.Forms;
using gorilla.commons.utility;
using momoney.presentation.resources;
using MoMoney.Presentation.Views;
using MoMoney.Presentation.Winforms.Helpers;
using WeifenLuo.WinFormsUI.Docking;

namespace MoMoney.Presentation.Winforms.Views
{
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
                //if (window_is_already_contained_in(panel)) 
                //    remove_from(panel);

                Show(panel, dock_state);
            }
        }

        //void remove_from(DockPanel panel)
        //{
        //    using (new SuspendLayout(panel))
        //    {
        //        //var panel_to_remove = get_window_from(panel);
        //        //panel_to_remove.DockHandler.Close();
        //        //panel_to_remove.DockHandler.Dispose();
        //    }
        //}

        //IDockContent get_window_from(DockPanel panel)
        //{
        //    return panel.Documents.Single(matches);
        //}

        //bool window_is_already_contained_in(DockPanel panel)
        //{
        //    return panel.Documents.Count(matches) > 0;
        //}

        //bool matches(IDockContent x)
        //{
        //    return x.DockHandler.TabText.Equals(TabText);
        //}
    }
}