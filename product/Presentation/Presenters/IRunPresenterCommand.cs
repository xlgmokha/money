using MoMoney.Presentation.Core;

namespace MoMoney.Presentation.Presenters
{
    public interface IRunPresenterCommand
    {
        void run<Presenter>() where Presenter : IPresenter;
    }
}