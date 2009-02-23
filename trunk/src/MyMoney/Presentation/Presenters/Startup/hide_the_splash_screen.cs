using System;
using MyMoney.Infrastructure.Threading;
using MyMoney.Presentation.Views.Startup;

namespace MyMoney.Presentation.Presenters.Startup
{
    public class hide_the_splash_screen : ISplashScreenState
    {
        private readonly ITimer timer;
        private readonly ISplashScreenView view;
        private readonly ISplashScreenPresenter presenter;

        public hide_the_splash_screen(ITimer timer, ISplashScreenView view, ISplashScreenPresenter presenter)
        {
            this.timer = timer;
            this.view = view;
            this.presenter = presenter;
            timer.start_notifying(presenter, new TimeSpan(50));
        }

        public void update()
        {
            if (view.current_opacity() == 0) {
                view.close_the_screen();
                timer.stop_notifying(presenter);
            }
            else {
                view.decrement_the_opacity();
            }
        }
    }
}