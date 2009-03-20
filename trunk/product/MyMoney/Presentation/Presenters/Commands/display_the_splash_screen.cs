using System;
using MoMoney.Infrastructure.Threading;
using MoMoney.Presentation.Presenters.Startup;
using MoMoney.Presentation.Views.Startup;
using MoMoney.Utility.Core;
using MoMoney.Utility.Extensions;

namespace MoMoney.Presentation.Presenters.Commands
{
    public class display_the_splash_screen : IDisposableCommand
    {
        readonly Func<ISplashScreenPresenter> presenter;

        public display_the_splash_screen()
            : this(() => new SplashScreenPresenter(new IntervalTimer(new TimerFactory()), new SplashScreenView()))
        {
        }

        public display_the_splash_screen(Func<ISplashScreenPresenter> presenter)
        {
            this.presenter = presenter.memorize();
        }

        public void run()
        {
            presenter().run();
        }

        public void Dispose()
        {
            presenter().Dispose();
        }
    }
}