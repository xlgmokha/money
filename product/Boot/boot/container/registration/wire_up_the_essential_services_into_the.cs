using Gorilla.Commons.Infrastructure.Logging;
using gorilla.commons.infrastructure.thirdparty;
using gorilla.commons.infrastructure.thirdparty.Log4Net;
using gorilla.commons.utility;

namespace MoMoney.boot.container.registration
{
    class wire_up_the_essential_services_into_the : Command
    {
        readonly DependencyRegistration registration;

        public wire_up_the_essential_services_into_the(DependencyRegistration registration)
        {
            this.registration = registration;
        }

        public void run()
        {
            registration.singleton(() => registration);
            registration.singleton(() => registration.build());
            registration.singleton<LogFactory, Log4NetLogFactory>();
        }
    }
}