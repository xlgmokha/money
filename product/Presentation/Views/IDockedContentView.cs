using WeifenLuo.WinFormsUI.Docking;

namespace MoMoney.Presentation.Views
{
    public interface IDockedContentView : IDockContent, IView
    {
        void add_to(DockPanel panel);
    }
}