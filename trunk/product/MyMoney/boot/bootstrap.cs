using System;
using MoMoney.boot.container;
using MoMoney.Infrastructure.Extensions;
using MoMoney.Presentation.Presenters.Startup;
using MoMoney.Utility.Extensions;
using MoMoney.windows.ui;
using display_the_splash_screen=MoMoney.Presentation.Presenters.Commands.display_the_splash_screen;

namespace MoMoney.boot
{
    internal static class bootstrap
    {
        [STAThread]
        static void Main()
        {
            Func<ISplashScreenPresenter> presenter = () => new SplashScreenPresenter();
            presenter = presenter.memorize();

            var startup_screen = new display_the_splash_screen(presenter).on_a_background_thread();
            hookup
                .the<global_error_handling>()
                .then(startup_screen)
                .then<wire_up_the_container>()
                .then(startup_screen.Dispose)
                .then<start_the_application>()
                .run();
        }
    }
}