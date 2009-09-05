using System.Windows.Forms;
using Gorilla.Commons.Windows.Forms.Resources;
using MoMoney.Presentation.Views.Core;
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
}