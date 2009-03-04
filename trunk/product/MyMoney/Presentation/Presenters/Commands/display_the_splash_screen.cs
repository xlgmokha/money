using MyMoney.Infrastructure.Threading;
using MyMoney.Presentation.Presenters.Startup;
using MyMoney.Presentation.Views.Startup;
using MyMoney.Utility.Core;

namespace MyMoney.Presentation.Presenters.Commands
{
    public class display_the_splash_screen : IDisposableCommand
    {
        readonly ISplashScreenPresenter presenter;

        public display_the_splash_screen()
            : this(new SplashScreenPresenter(new IntervalTimer(new TimerFactory()), new SplashScreenView()))
        {
        }

        public display_the_splash_screen(ISplashScreenPresenter presenter)
        {
            this.presenter = presenter;
        }

        public void run()
        {
            presenter.run();
        }

        public void Dispose()
        {
            presenter.Dispose();
        }
    }
}