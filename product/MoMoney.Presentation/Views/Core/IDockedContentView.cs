using WeifenLuo.WinFormsUI.Docking;

namespace MoMoney.Presentation.Views.Core
{
    public interface IDockedContentView : IDockContent, IView
    {
        void add_to(DockPanel panel);
    }
}