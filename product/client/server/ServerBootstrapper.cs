using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using Autofac.Builder;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Infrastructure.Logging;
using gorilla.commons.infrastructure.thirdparty.Autofac;
using gorilla.commons.infrastructure.thirdparty.Log4Net;
using gorilla.commons.infrastructure.threading;
using gorilla.commons.utility;
using presentation.windows.common;
using presentation.windows.server.handlers;
using presentation.windows.server.orm;
using presentation.windows.server.orm.nhibernate;
using Rhino.Queues;
using ISession = NHibernate.ISession;
using ISessionFactory = NHibernate.ISessionFactory;

namespace presentation.windows.server
{
    public class ServerBootstrapper
    {
        static public void run()
        {
            new ConfigureApplicationDirectory().run();

            var builder = new ContainerBuilder();
            var registry = new AutofacDependencyRegistryBuilder(builder).build();
            Resolve.initialize_with(registry);

            builder.Register(x => registry).As<DependencyRegistry>().SingletonScoped();
            //needs startups
            builder.Register<StartServiceBus>().As<NeedStartup>();
            builder.Register<ConfigureMappings>().As<NeedStartup>();

            // infrastructure
            builder.Register<Log4NetLogFactory>().As<LogFactory>().SingletonScoped();
            builder.Register<DefaultMapper>().As<Mapper>().SingletonScoped();

            var manager = new QueueManager(new IPEndPoint(IPAddress.Loopback, 2200), "server.esent");
            manager.CreateQueues("server");
            builder.Register(x => new RhinoPublisher("client", 2201, manager)).As<ServiceBus>().SingletonScoped();
            builder.Register(x => new RhinoReceiver(manager.GetQueue("server"), x.Resolve<CommandProcessor>())).As<RhinoReceiver>().As<Receiver>().SingletonScoped();

            var session_factory = new NHibernateBootstrapper().fetch();
            builder.Register<ISessionFactory>(x => session_factory).SingletonScoped();
            builder.Register<ISession>(x => current_session(x));
            builder.Register<NHibernateUnitOfWorkFactory>().As<IUnitOfWorkFactory>();
            builder.Register<IContext>(x => create_application_context()).SingletonScoped();

            register_handlers(builder);
            register_repositories(builder);

            Resolve.the<IEnumerable<NeedStartup>>().each(x => x.run());
            Resolve.the<CommandProcessor>().run();
        }

        static void register_handlers(ContainerBuilder builder)
        {
            builder.Register<SynchronousCommandProcessor>().As<CommandProcessor>().SingletonScoped();
            builder.Register<AddNewFamilyMemberHandler>().As<Handler>();
            builder.Register<FindAllFamilyHandler>().As<Handler>();
            builder.Register<CreateNewDetailAccountHandler>().As<Handler>();
            builder.Register<ShutdownApplicationCommand>().As<Handler>();

        }

        static void register_repositories(ContainerBuilder builder)
        {
            builder.Register<NHibernatePersonRepository>().As<PersonRepository>().FactoryScoped();
            builder.Register<NHibernateAccountRepository>().As<AccountRepository>().FactoryScoped();
        }

        static IContext create_application_context()
        {
            return new ContextFactory().create_for(new PerThreadScopedStorage(new CurrentThread()));
        }

        static ISession current_session(Autofac.IContext x)
        {
            var context = x.Resolve<IContext>();
            var session = context.value_for(new TypedKey<ISession>());
            if (null == session) Debugger.Break();
            return session;
        }
    }
}