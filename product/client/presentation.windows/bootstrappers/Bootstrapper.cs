using System.Collections.Generic;
using System.ComponentModel;
using Autofac.Builder;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Infrastructure.Logging;
using gorilla.commons.infrastructure.thirdparty.Autofac;
using gorilla.commons.infrastructure.thirdparty.Log4Net;
using gorilla.commons.utility;
using MoMoney.Service.Infrastructure.Eventing;
using MoMoney.Service.Infrastructure.Threading;
using presentation.windows.commands;
using presentation.windows.presenters;
using presentation.windows.views;

namespace presentation.windows.bootstrappers
{
    static public class Bootstrapper
    {
        static public ShellWindow create_window()
        {
            var builder = new ContainerBuilder();
            var shell_window = new ShellWindow();
            builder.Register(x => shell_window).SingletonScoped();
            builder.Register(x => shell_window).As<RegionManager>().SingletonScoped();

            //needs startups
            builder.Register<ComposeShell>().As<NeedStartup>();

            // infrastructure
            builder.Register<Log4NetLogFactory>().As<LogFactory>().SingletonScoped();

            // presentation infrastructure
            builder.Register<WpfApplicationController>().As<ApplicationController>().SingletonScoped();
            builder.Register<WpfPresenterFactory>().As<PresenterFactory>().SingletonScoped();
            builder.Register<SynchronizedEventAggregator>().As<EventAggregator>().SingletonScoped();
            builder.Register(x => AsyncOperationManager.SynchronizationContext);

            // presenters
            builder.Register<StatusBarPresenter>().SingletonScoped();
            builder.Register<CompensationPresenter>();
            builder.Register<AddFamilyMemberPresenter>();

            // commanding
            builder.Register<ContainerCommandBuilder>().As<CommandBuilder>().SingletonScoped();
            builder.Register<AsynchronousCommandProcessor>().As<CommandProcessor>().SingletonScoped();
            builder.Register<AddFamilyMember>();

            Resolve.initialize_with(new AutofacDependencyRegistryBuilder(builder).build());
            Resolve.the<IEnumerable<NeedStartup>>().each(x => x.run());
            Resolve.the<CommandProcessor>().run();

            return shell_window;
        }
    }
}