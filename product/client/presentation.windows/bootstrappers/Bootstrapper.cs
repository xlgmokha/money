using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using MoMoney.Service.Infrastructure.Eventing;
using MoMoney.Service.Infrastructure.Threading;
using momoney.service.infrastructure.transactions;
using NHibernate.ByteCode.Castle;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using presentation.windows.commands;
using presentation.windows.infrastructure;
using presentation.windows.orm;
using presentation.windows.orm.mappings;
using presentation.windows.orm.nhibernate;
using presentation.windows.presenters;
using presentation.windows.queries;
using presentation.windows.views;
using Environment = System.Environment;
using ISession = NHibernate.ISession;
using ISessionFactory = NHibernate.ISessionFactory;

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
            builder.Register<ConfigureMappings>().As<NeedStartup>();

            // infrastructure
            builder.Register<Log4NetLogFactory>().As<LogFactory>().SingletonScoped();
            builder.Register<DefaultMapper>().As<Mapper>().SingletonScoped();

            var session_factory = bootstrap_nhibernate();
            builder.Register(x => session_factory).SingletonScoped();
            builder.Register(x => x.Resolve<IContext>().value_for(new TypedKey<ISession>()));
            builder.Register<NHibernateUnitOfWorkFactory>().As<IUnitOfWorkFactory>();
            builder.Register(x => new ContextFactory().create_for(new PerThreadScopedStorage(new CurrentThread())));

            // presentation infrastructure
            builder.Register<WpfApplicationController>().As<ApplicationController>().SingletonScoped();
            builder.Register<WpfPresenterFactory>().As<PresenterFactory>().SingletonScoped();
            builder.Register<SynchronizedEventAggregator>().As<EventAggregator>().SingletonScoped();
            builder.Register(x => AsyncOperationManager.SynchronizationContext);

            // presenters
            builder.Register<StatusBarPresenter>().SingletonScoped();
            builder.Register<CompensationPresenter>();
            builder.Register<AddFamilyMemberPresenter>();
            builder.Register<SelectedFamilyMemberPresenter>();

            // commanding
            builder.Register<ContainerCommandBuilder>().As<CommandBuilder>().SingletonScoped();
            builder.Register<AsynchronousCommandProcessor>().As<CommandProcessor>().SingletonScoped();
            builder.Register<AddFamilyMemberCommand>();

            // queries
            builder.Register<FindMemberIdentifiedBy>();
            builder.Register<FindAllFamily>();
            builder.Register<ContainerAwareQueryBuilder>().As<QueryBuilder>();

            // repositories
            builder.Register<NHibernatePersonRepository>().As<PersonRepository>();

            Resolve.initialize_with(new AutofacDependencyRegistryBuilder(builder).build());
            Resolve.the<IEnumerable<NeedStartup>>().each(x => x.run());
            Resolve.the<CommandProcessor>().run();

            return shell_window;
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
            //var database_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"mokhan.ca\momoney\default.db");
            //if (!File.Exists(database_path))
            {
                //Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"mokhan.ca\momoney"));
                var export = new SchemaExport(configuration);
                export.Execute(true, true, false);
            }
        }
    }
}