using Gorilla.Commons.Infrastructure.Reflection;
using gorilla.commons.infrastructure.thirdparty;
using MoMoney.Domain.Accounting;

namespace MoMoney.boot.container.registration
{
    class WireUpTheDomainServicesInToThe : IStartupCommand
    {
        readonly DependencyRegistration registry;

        public WireUpTheDomainServicesInToThe(DependencyRegistration registry)
        {
            this.registry = registry;
        }

        public void run_against(Assembly item)
        {
            registry.transient<ICompanyFactory, CompanyFactory>();
        }
    }
}