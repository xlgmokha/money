using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
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
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Func<ISplashScreenPresenter> presenter = () => new SplashScreenPresenter();
            presenter = presenter.memorize();

            var startup_screen = new display_the_splash_screen(presenter).on_a_background_thread();

            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            hookup
                .the<global_error_handling>()
                .then(startup_screen)
                .then<wire_up_the_container>()
                .then(new start_the_application(startup_screen))
                .run();

            stopwatch.Stop();
            this.log().debug("application startup took: {0}", stopwatch.Elapsed);
            start();
        }

        void start()
        {
            try
            {
                Application.Run(resolve.dependency_for<Shell>());
            }
            catch (Exception e)
            {
                this.log().error(e);
                resolve.dependency_for<IEventAggregator>().publish(new UnhandledErrorOccurred(e));
            }
        }
    }

    public class ApplicationContainer : Container
    {
        readonly IServiceContainer container;

        public ApplicationContainer() : this(new ServiceContainer())
        {
        }

        public ApplicationContainer(IServiceContainer container)
        {
            this.container = container;
        }

        protected override object GetService(Type service)
        {
            return container.GetService(service) ?? base.GetService(service);
        }
    }
}