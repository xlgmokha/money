using System.Collections.Generic;
using System.Threading;
using System.Windows.Threading;
using Autofac.Builder;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Infrastructure.Logging;
using gorilla.commons.infrastructure.thirdparty.Autofac;
using gorilla.commons.infrastructure.thirdparty.Log4Net;
using gorilla.commons.utility;
using MoMoney.Service.Infrastructure.Eventing;
using MoMoney.Service.Infrastructure.Threading;
using presentation.windows.common;
using presentation.windows.common.messages;
using presentation.windows.presenters;
using presentation.windows.queries;
using presentation.windows.service.infrastructure;
using presentation.windows.views;

namespace presentation.windows.bootstrappers
{
    static public class Bootstrapper
    {
        static public ShellWindow create_window()
        {
            var builder = new ContainerBuilder();
            Resolve.initialize_with(new AutofacDependencyRegistryBuilder(builder).build());
            var shell_window = new ShellWindow();
            builder.Register(x => shell_window).SingletonScoped();
            builder.Register(x => shell_window).As<RegionManager>().SingletonScoped();

            //needs startups
            builder.Register<ComposeShell>().As<NeedStartup>();
            builder.Register<ConfigureMappings>().As<NeedStartup>();

            // infrastructure
            builder.Register<Log4NetLogFactory>().As<LogFactory>().SingletonScoped();
            builder.Register<DefaultMapper>().As<Mapper>().SingletonScoped();

            // presentation infrastructure
            SynchronizationContext.SetSynchronizationContext(new DispatcherSynchronizationContext());
            builder.Register<WpfApplicationController>().As<ApplicationController>().SingletonScoped();
            builder.Register<WpfPresenterFactory>().As<PresenterFactory>().SingletonScoped();
            builder.Register<SynchronizedEventAggregator>().As<EventAggregator>().SingletonScoped();
            //builder.Register(x => AsyncOperationManager.SynchronizationContext);
            builder.Register(x => SynchronizationContext.Current);

            // presenters
            builder.Register<StatusBarPresenter>().SingletonScoped();
            builder.Register<CompensationPresenter>().SingletonScoped();
            builder.Register<SelectedFamilyMemberPresenter>().SingletonScoped();
            builder.Register<AddFamilyMemberPresenter>();
            builder.Register<AccountPresenter>();
            builder.Register<AccountPresenter.AddNewAccountCommand>();
            builder.Register<AddFamilyMemberPresenter.SaveCommand>();
            builder.Register<CancelCommand>();

            // commanding
            builder.Register<ContainerCommandBuilder>().As<CommandBuilder>().SingletonScoped();
            builder.Register<AsynchronousCommandProcessor>().As<CommandProcessor>().SingletonScoped();
            builder.Register<WpfCommandBuilder>().As<UICommandBuilder>();

            // queries
            builder.Register<FindAllFamily>();
            builder.Register<ContainerAwareQueryBuilder>().As<QueryBuilder>();

            Resolve.the<IEnumerable<NeedStartup>>().each(x => x.run());
            Resolve.the<CommandProcessor>().run();

            shell_window.Closed += (o, e) => Resolve.the<CommandProcessor>().stop();
            return shell_window;
        }
    }
}