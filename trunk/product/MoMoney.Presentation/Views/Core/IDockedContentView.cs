using Gorilla.Commons.Windows.Forms;
using MoMoney.Presentation.Core;
using WeifenLuo.WinFormsUI.Docking;

namespace MoMoney.Presentation.Views.core
{
    public interface IDockedContentView : IDockContent, IView
    {
        void add_to(DockPanel panel);
    }

    public interface IView<Presenter> : IView where Presenter : IPresenter
    {
        void attach_to(Presenter presenter);
    }
}