using Gorilla.Commons.Infrastructure;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Infrastructure.Transactions;
using Gorilla.Commons.Utility.Core;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.boot.container.registration.proxy_configuration;
using MoMoney.DataAccess;

namespace MoMoney.boot.container.registration
{
    internal class wire_up_the_data_access_components_into_the : ICommand
    {
        readonly IDependencyRegistration register;

        public wire_up_the_data_access_components_into_the(IDependencyRegistration registry)
        {
            register = registry;
        }

        public void run()
        {
            register.singleton<IDatabase, ObjectDatabase>();
            register.singleton(() => Resolve.the<IDatabase>().downcast_to<IDatabaseConfiguration>());
            register.proxy<ISession, NoConfiguration<ISession>>( () => Resolve.the<ISessionProvider>().get_the_current_session());
        }
    }
}