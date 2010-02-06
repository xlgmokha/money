using Gorilla.Commons.Infrastructure.Logging;
using Gorilla.Commons.Infrastructure.Reflection;
using gorilla.commons.infrastructure.thirdparty;
using gorilla.commons.infrastructure.thirdparty.Log4Net;

namespace MoMoney.boot.container.registration
{
    class WireUpTheEssentialServicesIntoThe : IStartupCommand
    {
        readonly DependencyRegistration registration;

        public WireUpTheEssentialServicesIntoThe(DependencyRegistration registration)
        {
            this.registration = registration;
        }

        public void run_against(Assembly item)
        {
            registration.singleton(() => registration);
            registration.singleton(() => registration.build());
            registration.singleton<LogFactory, Log4NetLogFactory>();
        }
    }
}