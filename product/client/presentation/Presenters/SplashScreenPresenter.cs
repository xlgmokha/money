using gorilla.commons.Utility;
using momoney.presentation.presenters;
using momoney.presentation.views;
using momoney.service.infrastructure.threading;
using MoMoney.Service.Infrastructure.Threading;

namespace MoMoney.Presentation.Presenters
{
    public interface ISplashScreenPresenter : DisposableCommand, ITimerClient {}

    public class SplashScreenPresenter : ISplashScreenPresenter
    {
        readonly ITimer timer;
        readonly ISplashScreenView view;
        ISplashScreenState current_state;

        public SplashScreenPresenter(ITimer timer, ISplashScreenView view)
        {
            this.timer = timer;
            this.view = view;
        }

        public void run()
        {
            view.display();
            current_state = new DisplayTheSplashScreen(timer, view, this);
        }

        public void Dispose()
        {
            current_state = new HideTheSplashScreen(timer, view, this);
        }

        public void notify()
        {
            current_state.update();
        }
    }
}