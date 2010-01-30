using WeifenLuo.WinFormsUI.Docking;

namespace momoney.presentation.views
{
    public interface ITab : IDockContent, View
    {
        void add_to(DockPanel panel);
    }
}