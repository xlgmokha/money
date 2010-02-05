using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Windows;
using Autofac.Builder;
using Gorilla.Commons.Infrastructure.Container;
using gorilla.commons.infrastructure.thirdparty.Autofac;
using gorilla.commons.utility;

namespace presentation.windows
{
    static public class Program
    {
        [STAThread]
        static public void Main()
        {
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            var application = new Application();
            application.DispatcherUnhandledException += (o, e) => {};
            application.ShutdownMode = ShutdownMode.OnMainWindowClose;
            application.Run(create_window());
        }

        static ShellWindow create_window()
        {
            var builder = new ContainerBuilder();
            var shell_window = new ShellWindow();
            builder.Register(x => shell_window).As<RegionManager>();
            builder.Register<ComposeShell>().As<NeedStartup>();
            builder.Register<WpfApplicationController>().As<ApplicationController>();
            builder.Register<WpfPresenterFactory>().As<PresenterFactory>();
            builder.Register<CompensationPresenter>();

            Resolve.initialize_with(new AutofacDependencyRegistryBuilder(builder).build());
            Resolve.the<IEnumerable<NeedStartup>>().each(x => x.run());
            return shell_window;
        }
    }
}