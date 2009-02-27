using System;
using System.Linq;
using System.Windows.Forms;
using MyMoney.Presentation.Resources;
using WeifenLuo.WinFormsUI.Docking;

namespace MyMoney.Presentation.Views.core
{
    public interface IApplicationDockedWindow : IDockedContentView
    {
        IApplicationDockedWindow create_tool_tip_for(string title, string caption, Control control);
        IApplicationDockedWindow titled(string title);
        IApplicationDockedWindow icon(ApplicationIcon icon);
    }

    public partial class ApplicationDockedWindow : DockContent, IApplicationDockedWindow
    {
        public ApplicationDockedWindow()
        {
            InitializeComponent();
            Id = Guid.NewGuid();
            TabText = "Undefined";
            Icon = ApplicationIcons.Application;
        }

        Guid Id { get; set; }

        public IApplicationDockedWindow create_tool_tip_for(string title, string caption, Control control)
        {
            new ToolTip {IsBalloon = true, ToolTipTitle = title}.SetToolTip(control, caption);
            return this;
        }

        public IApplicationDockedWindow titled(string title)
        {
            TabText = title;
            return this;
        }

        public IApplicationDockedWindow icon(ApplicationIcon icon)
        {
            Icon = icon;
            return this;
        }

        public void AddTo(DockPanel panel)
        {
            var panel_to_remove = panel.Documents.SingleOrDefault(x => x.DockHandler.TabText.Equals(TabText));
            if (panel_to_remove != null)
            {
                panel_to_remove.DockHandler.Close();
                panel_to_remove.DockHandler.Dispose();
            }
            Show(panel);
        }
    }
}