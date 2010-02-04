using momoney.presentation.resources;
using momoney.presentation.views;
using WeifenLuo.WinFormsUI.Docking;

namespace MoMoney.Presentation.Views
{
    public interface IApplicationDockedWindow : ITab
    {
        IApplicationDockedWindow titled(string title, params object[] arguments);
        IApplicationDockedWindow icon(ApplicationIcon icon);
        IApplicationDockedWindow cannot_be_closed();
        IApplicationDockedWindow docked_to(DockState state);
    }
}