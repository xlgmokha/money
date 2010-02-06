using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Windows;
using Autofac.Builder;
using Gorilla.Commons.Infrastructure.Container;
using gorilla.commons.infrastructure.thirdparty.Autofac;
using gorilla.commons.utility;
using MoMoney.Service.Infrastructure.Threading;
using presentation.windows.commands;
using presentation.windows.presenters;
using presentation.windows.views;

namespace presentation.windows
{
    static public class Program
    {
        [STAThread]
        static public void Main()
        {
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            var application = new Application();
            application.DispatcherUnhandledException += (o, e) =>
            {
                MessageBox.Show(e.to_string());
            };
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
            builder.Register<AddFamilyMemberPresenter>();

            builder.Register<ContainerCommandBuilder>().As<CommandBuilder>();
            builder.Register<SynchronousCommandProcessor>().As<CommandProcessor>();


            Resolve.initialize_with(new AutofacDependencyRegistryBuilder(builder).build());
            Resolve.the<IEnumerable<NeedStartup>>().each(x => x.run());
            return shell_window;
        }
    }
}