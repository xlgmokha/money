using WeifenLuo.WinFormsUI.Docking;

namespace momoney.presentation.views
{
    public interface IDockedContentView : IDockContent, IView
    {
        void add_to(DockPanel panel);
    }
}