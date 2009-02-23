using MyMoney.Presentation.Core;

namespace MyMoney.Presentation.Views.core
{
    public interface IView<Presenter> where Presenter : IPresenter
    {
        void attach_to(Presenter presenter);
    }
}