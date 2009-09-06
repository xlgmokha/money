using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Globalization;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Infrastructure.Logging;
using Gorilla.Commons.Infrastructure.Threading;
using Gorilla.Commons.Utility.Core;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.boot.container;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Presenters;
using MoMoney.Service.Infrastructure.Eventing;
using MoMoney.windows.ui;

namespace MoMoney.boot
{
    public class WindowsFormsApplication<Shell> : ICommand where Shell : Form
    {
        protected WindowsFormsApplication()
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
                Application.Run(Resolve.the<Shell>());
            }
            catch (Exception e)
            {
                this.log().error(e);
                Resolve.the<IEventAggregator>().publish(new UnhandledErrorOccurred(e));
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