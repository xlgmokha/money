using WeifenLuo.WinFormsUI.Docking;

namespace momoney.presentation.views
{
    public interface IDockedContentView : IDockContent, View
    {
        void add_to(DockPanel panel);
    }
}