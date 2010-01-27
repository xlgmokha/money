using MoMoney.Presentation.Core;

namespace momoney.presentation.views
{
    public interface IDialog<Presenter> : IView<Presenter> where Presenter : DialogPresenter
    {
    }
}