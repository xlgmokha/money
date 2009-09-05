using Gorilla.Commons.Infrastructure;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Infrastructure.Log4Net;
using Gorilla.Commons.Infrastructure.Logging;
using Gorilla.Commons.Utility.Core;

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
            registration.singleton<IDependencyRegistration>(() => registration);
            registration.singleton<IDependencyRegistry>(() => registration.build());
            registration.singleton<ILogFactory, Log4NetLogFactory>();
        }
    }
}