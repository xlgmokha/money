using Gorilla.Commons.Infrastructure.Cloning;
using Gorilla.Commons.Infrastructure.Container;
using gorilla.commons.infrastructure.thirdparty;
using gorilla.commons.utility;
using MoMoney.boot.container.registration.proxy_configuration;
using momoney.database;
using momoney.database.db4o;
using momoney.database.transactions;
using MoMoney.Service.Contracts.Infrastructure.Transactions;
using MoMoney.Service.Infrastructure.Transactions;

namespace MoMoney.boot.container.registration
{
    class wire_up_the_data_access_components_into_the : Command
    {
        readonly DependencyRegistration register;

        public wire_up_the_data_access_components_into_the(DependencyRegistration registry)
        {
            register = registry;
        }

        public void run()
        {
            register.singleton<IDatabase, ObjectDatabase>();
            register.singleton(() => Resolve.the<IDatabase>().downcast_to<IDatabaseConfiguration>());
            register.transient<ISessionProvider, SessionProvider>();
            register.proxy<ISession, NoConfiguration<ISession>>(
                () => Resolve.the<ISessionProvider>().get_the_current_session());

            register.transient<IUnitOfWorkInterceptor, UnitOfWorkInterceptor>();
            register.transient<IUnitOfWorkFactory, UnitOfWorkFactory>();
            register.transient<ISessionFactory, SessionFactory>();
            register.transient<IChangeTrackerFactory, ChangeTrackerFactory>();
            register.transient<IStatementRegistry, StatementRegistry>();
            register.transient<IConnectionFactory, ConnectionFactory>();
            register.transient<IConfigureDatabaseStep, ConfigureDatabaseStep>();
            register.transient<IConfigureObjectContainerStep, ConfigureObjectContainerStep>();
            register.transient<IPrototype, Prototype>();
        }
    }
}