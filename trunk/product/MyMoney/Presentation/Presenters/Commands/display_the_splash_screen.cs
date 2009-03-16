using MoMoney.Presentation.Presenters.Startup;
using MoMoney.Utility.Core;

namespace MoMoney.Presentation.Presenters.Commands
{
    public class display_the_splash_screen : IDisposableCommand
    {
        readonly ISplashScreenPresenter presenter;

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