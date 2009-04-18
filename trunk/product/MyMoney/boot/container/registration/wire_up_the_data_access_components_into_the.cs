using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Utility.Core;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.Infrastructure.Container;
using MoMoney.Infrastructure.transactions2;

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
            //register.singleton<ISessionContext, SessionContext>();
            register.singleton<IDatabase, Database>();
            register.singleton(() => Resolve.dependency_for<IDatabase>().downcast_to<IDatabaseConfiguration>());
            register.singleton<ISession>(() => Resolve.dependency_for<ISessionProvider>().get_the_current_session());
        }
    }
}