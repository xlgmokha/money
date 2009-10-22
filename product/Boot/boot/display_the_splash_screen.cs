using System;
using gorilla.commons.Utility;
using MoMoney.Presentation.Presenters;

namespace MoMoney.boot
{
    public class display_the_splash_screen : DisposableCommand
    {
        readonly Func<ISplashScreenPresenter> presenter;

        public display_the_splash_screen(Func<ISplashScreenPresenter> presenter)
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