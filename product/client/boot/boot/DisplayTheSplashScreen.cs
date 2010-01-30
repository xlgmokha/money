using System;
using gorilla.commons.Utility;
using MoMoney.Presentation.Presenters;

namespace MoMoney.boot
{
    public class DisplayTheSplashScreen : DisposableCommand
    {
        readonly Func<ISplashScreenPresenter> presenter;

        public DisplayTheSplashScreen(Func<ISplashScreenPresenter> presenter)
        {
            this.presenter = presenter;
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