using MoMoney.DataAccess.db40;
using MoMoney.Infrastructure.Container;
using MoMoney.Utility.Core;

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
            register.singleton<ISessionContext, SessionContext>();
        }
    }
}