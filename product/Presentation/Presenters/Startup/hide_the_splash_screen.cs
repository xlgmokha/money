using System;
using Gorilla.Commons.Infrastructure.Threading;
using MoMoney.Presentation.Views.Startup;

namespace MoMoney.Presentation.Presenters.Startup
{
    public class hide_the_splash_screen : ISplashScreenState
    {
        readonly ITimer timer;
        readonly ISplashScreenView view;
        readonly ISplashScreenPresenter presenter;

        public hide_the_splash_screen(ITimer timer, ISplashScreenView view, ISplashScreenPresenter presenter)
        {
            this.timer = timer;
            this.view = view;
            this.presenter = presenter;
            timer.start_notifying(presenter, new TimeSpan(50));
        }

        public void update()
        {
            if (view.current_opacity() == 0)
            {
                timer.stop_notifying(presenter);
                view.close_the_screen();
            }
            else
            {
                view.decrement_the_opacity();
            }
        }
    }
}