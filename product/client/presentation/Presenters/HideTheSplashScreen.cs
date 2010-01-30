using System;
using MoMoney.Presentation.Presenters;
using momoney.presentation.views;
using MoMoney.Service.Infrastructure.Threading;

namespace momoney.presentation.presenters
{
    public class HideTheSplashScreen : ISplashScreenState
    {
        readonly ITimer timer;
        readonly ISplashScreenView view;
        readonly ISplashScreenPresenter presenter;

        public HideTheSplashScreen(ITimer timer, ISplashScreenView view, ISplashScreenPresenter presenter)
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