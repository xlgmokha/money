using System;
using MoMoney.Infrastructure.Extensions;
using MoMoney.Presentation.Presenters.Commands;
using MoMoney.Utility.Extensions;

namespace MoMoney.windows.ui
{
    internal static class bootstrap
    {
        [STAThread]
        static void Main()
        {
            var startup_screen = new display_the_splash_screen().on_a_background_thread();
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