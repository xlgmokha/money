using System.Collections.Generic;
using System.Net;
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
using Rhino.Queues;

namespace presentation.windows.bootstrappers
{
    static public class Bootstrapper
    {
        static public ShellWindow create_window()
        {
            var builder = new ContainerBuilder();
            var registry = new AutofacDependencyRegistryBuilder(builder).build();
            Resolve.initialize_with(registry);
            builder.Register(x => registry).As<DependencyRegistry>().SingletonScoped();

            var shell_window = new ShellWindow();
            builder.Register(x => shell_window).SingletonScoped();
            builder.Register(x => shell_window).As<RegionManager>().SingletonScoped();

            //needs startups
            builder.Register<StartServiceBus>().As<NeedStartup>();
            builder.Register<ComposeShell>().As<NeedStartup>();
            builder.Register<ConfigureMappings>().As<NeedStartup>();

            // infrastructure
            builder.Register<Log4NetLogFactory>().As<LogFactory>().SingletonScoped();
            builder.Register<DefaultMapper>().As<Mapper>().SingletonScoped();

            var manager = new QueueManager(new IPEndPoint(IPAddress.Loopback, 2201), "client.esent");
            manager.CreateQueues("client");
            builder.Register(x => new RhinoPublisher("server", 2200, manager)).As<ServiceBus>().SingletonScoped();
            builder.Register(x => new RhinoReceiver(manager.GetQueue("client"), x.Resolve<CommandProcessor>())).As<RhinoReceiver>().As<Receiver>().SingletonScoped();

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
            builder.Register<AddFamilyMemberPresenter.SaveCommand>();
            builder.Register<AccountPresenter>();
            builder.Register<AccountPresenter.AddNewAccountCommand>();
            builder.Register<CancelCommand>();

            // commanding
            builder.Register<ContainerCommandBuilder>().As<CommandBuilder>().SingletonScoped();
            builder.Register<AsynchronousCommandProcessor>().As<CommandProcessor>().SingletonScoped();
            //builder.Register<SynchronousCommandProcessor>().As<CommandProcessor>().SingletonScoped();
            builder.Register<WpfCommandBuilder>().As<UICommandBuilder>();

            // queries
            builder.Register<ContainerAwareQueryBuilder>().As<QueryBuilder>();

            builder.Register<PublishEventHandler<AddedNewFamilyMember>>().As<Handler>();

            Resolve.the<IEnumerable<NeedStartup>>().each(x => x.run());
            Resolve.the<CommandProcessor>().run();

            shell_window.Closed += (o, e) => Resolve.the<CommandProcessor>().stop();
            return shell_window;
        }
    }
}