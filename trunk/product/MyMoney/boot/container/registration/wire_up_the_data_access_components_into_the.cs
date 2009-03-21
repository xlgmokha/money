using MoMoney.DataAccess.db40;
using MoMoney.Infrastructure.Container.Windsor;
using MoMoney.Utility.Core;

namespace MoMoney.boot.container.registration
{
    internal class wire_up_the_data_access_components_into_the : ICommand
    {
        readonly IContainerBuilder register;

        public wire_up_the_data_access_components_into_the(IContainerBuilder registry)
        {
            register = registry;
        }

        public void run()
        {
            register.singleton<ISessionContext, SessionContext>();
        }
    }
}