using MoMoney.Infrastructure.Threading;
using MoMoney.Presentation.Views.Startup;
using MoMoney.Utility.Core;

namespace MoMoney.Presentation.Presenters.Startup
{
    public interface ISplashScreenPresenter : IDisposableCommand, ITimerClient
    {
    }

    public class SplashScreenPresenter : ISplashScreenPresenter
    {
        private readonly ITimer timer;
        private readonly ISplashScreenView view;
        private ISplashScreenState current_state;

        public SplashScreenPresenter(ITimer timer, ISplashScreenView view)
        {
            this.timer = timer;
            this.view = view;
        }

        public void run()
        {
            view.display();
            current_state = new display_the_splash_screen(timer, view, this);
        }

        public void Dispose()
        {
            current_state = new hide_the_splash_screen(timer, view, this);
        }

        public void notify()
        {
            current_state.update();
        }
    }
}