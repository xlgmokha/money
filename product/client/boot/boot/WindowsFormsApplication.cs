using System;
using System.Diagnostics;
using System.Globalization;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Infrastructure.Logging;
using gorilla.commons.utility;
using momoney.boot;
using MoMoney.boot.container;
using momoney.presentation.model.eventing;
using MoMoney.Presentation.Presenters;
using MoMoney.Presentation.Winforms.Views;
using MoMoney.Service.Infrastructure.Eventing;
using momoney.service.infrastructure.threading;
using MoMoney.Service.Infrastructure.Threading;

namespace MoMoney.boot
{
    public class WindowsFormsApplication<Shell> : Command where Shell : Form
    {
        protected WindowsFormsApplication()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }

        public void run()
        {
            using (new LogTime())
            {
                Func<ISplashScreenPresenter> presenter = () => new SplashScreenPresenter(new IntervalTimer(), new SplashScreenView());
                presenter = presenter.memorize();

                var startup_screen = new DisplayTheSplashScreen(presenter).on_a_background_thread();

                AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
                Hookup
                    .the<GlobalErrorHandling>()
                    .then(startup_screen)
                    .then<WireUpTheContainer>()
                    .then(new StartTheApplication(startup_screen))
                    .run();
            }
            start();
        }

        void start()
        {
            try
            {
                Application.Run(Resolve.the<Shell>());
            }
            catch (Exception e)
            {
                this.log().error(e);
                Resolve.the<EventAggregator>().publish(new UnhandledErrorOccurred(e));
            }
        }
    }

    public class LogTime : IDisposable
    {
        Stopwatch stopwatch;

        public LogTime()
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        public void Dispose()
        {
            stopwatch.Stop();
            this.log().debug("application startup took: {0}", stopwatch.Elapsed);
        }
    }
}