using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Autofac.Builder;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Infrastructure.Logging;
using gorilla.commons.infrastructure.thirdparty.Autofac;
using gorilla.commons.infrastructure.thirdparty.Log4Net;
using gorilla.commons.utility;
using momoney.database.transactions;
using MoMoney.Service.Infrastructure.Threading;
using momoney.service.infrastructure.transactions;
using NHibernate.ByteCode.Castle;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using presentation.windows.common;
using presentation.windows.server.orm;
using presentation.windows.server.orm.mappings;
using presentation.windows.server.orm.nhibernate;
using Environment = System.Environment;
using ISessionFactory = NHibernate.ISessionFactory;

namespace presentation.windows.server
{
    public class Bootstrapper
    {
        static public void run()
        {
            var builder = new ContainerBuilder();
            Resolve.initialize_with(new AutofacDependencyRegistryBuilder(builder).build());

            //needs startups
            builder.Register<ConfigureMappings>().As<NeedStartup>();
            builder.Register<StartServiceBus>().As<NeedStartup>();

            // infrastructure
            builder.Register<Log4NetLogFactory>().As<LogFactory>().SingletonScoped();
            builder.Register<DefaultMapper>().As<Mapper>().SingletonScoped();
            builder.Register(x => new RhinoPublisher(23457, "client", "server_sender.esent", 23456)).As<ServiceBus>().SingletonScoped();
            builder.Register(x => new RhinoReceiver(23456, "server", "server_receiver.esent")).As<RhinoReceiver>().As<Receiver>().SingletonScoped();

            var session_factory = bootstrap_nhibernate();
            builder.Register(x => session_factory).SingletonScoped();
            builder.Register(x => current_session(x));
            builder.Register<NHibernateUnitOfWorkFactory>().As<IUnitOfWorkFactory>();
            builder.Register(x => create_application_context()).SingletonScoped();

            // commanding
            //builder.Register<ContainerCommandBuilder>().As<CommandBuilder>().SingletonScoped();
            builder.Register<AsynchronousCommandProcessor>().As<CommandProcessor>().SingletonScoped();
            //builder.Register<AddFamilyMemberCommand>();

            // queries

            // repositories
            builder.Register<NHibernatePersonRepository>().As<PersonRepository>().FactoryScoped();

            Resolve.the<IEnumerable<NeedStartup>>().each(x => x.run());
            Resolve.the<CommandProcessor>().run();
        }

        static IContext create_application_context()
        {
            return new ContextFactory().create_for(new PerThreadScopedStorage(new CurrentThread()));
        }

        static ISession current_session(Autofac.IContext x)
        {
            var session = x.Resolve<IContext>().value_for(new TypedKey<ISession>());
            if (null == session) Debugger.Break();
            return session;
        }

        static ISessionFactory bootstrap_nhibernate()
        {
            var configuration = new Configuration();
            var database_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"mokhan.ca\momoney\default.db");
            var fluent_configuration = Fluently
                .Configure(configuration)
                .Database(SQLiteConfiguration.Standard
                              .UsingFile(database_path)
                              .AdoNetBatchSize(500)
                              .ConnectionString(x => x.Is("Data Source={0};Version=3;New=True;".formatted_using(database_path)))
                              .ShowSql()
                              .ProxyFactoryFactory<ProxyFactoryFactory>()
                )
                .Mappings(x =>
                {
                    x.FluentMappings.AddFromAssemblyOf<MappingAssembly>();
                })
                .ExposeConfiguration(x => export(x))
                ;
            return fluent_configuration.BuildSessionFactory();
        }

        static void export(Configuration configuration)
        {
            var database_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"mokhan.ca\momoney\default.db");
            if (File.Exists(database_path))
            {
                File.Delete(database_path);
            }
            new SchemaExport(configuration).Execute(true, true, false);
        }
    }
}