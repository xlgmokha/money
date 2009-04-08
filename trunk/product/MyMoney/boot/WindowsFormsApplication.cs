using System;
using System.Globalization;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using MoMoney.boot.container;
using MoMoney.Infrastructure.Container;
using MoMoney.Infrastructure.eventing;
using MoMoney.Infrastructure.Extensions;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Presenters.Startup;
using MoMoney.Utility.Core;
using MoMoney.Utility.Extensions;
using MoMoney.windows.ui;
using display_the_splash_screen=MoMoney.Presentation.Presenters.Commands.display_the_splash_screen;

namespace MoMoney.boot
{
    public class WindowsFormsApplication<Shell> : ICommand where Shell : Form
    {
        public WindowsFormsApplication()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }

        public void run()
        {
            Func<ISplashScreenPresenter> presenter = () => new SplashScreenPresenter();
            presenter = presenter.memorize();

            var startup_screen = new display_the_splash_screen(presenter).on_a_background_thread();

            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            hookup
                .the<global_error_handling>()
                .then(startup_screen)
                .then<wire_up_the_container>()
                .then(startup_screen.Dispose)
                .then<start_the_application>()
                .run();

            start();
        }

        protected void start()
        {
            try
            {
                Application.Run(resolve.dependency_for<Shell>());
            }
            catch (Exception e)
            {
                this.log().error(e);
                resolve.dependency_for<IEventAggregator>().publish(new unhandled_error_occurred(e));
            }
        }
    }
}