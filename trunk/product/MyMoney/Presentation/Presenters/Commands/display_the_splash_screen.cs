using MoMoney.Infrastructure.Threading;
using MoMoney.Presentation.Presenters.Startup;
using MoMoney.Presentation.Views.Startup;
using MoMoney.Utility.Core;

namespace MoMoney.Presentation.Presenters.Commands
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