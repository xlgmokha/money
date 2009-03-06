using WeifenLuo.WinFormsUI.Docking;

namespace MoMoney.Presentation.Views.core
{
    public interface IDockedContentView : IDockContent, IView
    {
        void add_to(DockPanel panel);
    }
}