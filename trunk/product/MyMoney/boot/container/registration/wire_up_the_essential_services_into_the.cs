using System.Threading;
using MoMoney.Infrastructure.Container.Windsor;
using MoMoney.Infrastructure.Logging;
using MoMoney.Infrastructure.Logging.Log4NetLogging;
using MoMoney.Infrastructure.Threading;
using MoMoney.Utility.Core;

namespace MoMoney.boot.container.registration
{
    internal class wire_up_the_essential_services_into_the : ICommand
    {
        readonly IDependencyRegistration registration;

        public wire_up_the_essential_services_into_the(IDependencyRegistration registration)
        {
            this.registration = registration;
        }

        public void run()
        {
            registration.singleton<IDependencyRegistration>(registration);
            registration.singleton<ILogFactory, Log4NetLogFactory>();
            registration.singleton<ISynchronizationContext>(new SynchronizedContext(SynchronizationContext.Current));
        }
    }
}