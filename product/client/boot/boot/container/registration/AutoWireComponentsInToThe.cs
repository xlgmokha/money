using System;
using Gorilla.Commons.Infrastructure.Reflection;
using gorilla.commons.infrastructure.thirdparty;
using gorilla.commons.infrastructure.thirdparty.Castle.Windsor.Configuration;
using gorilla.commons.utility;

namespace MoMoney.boot.container.registration
{
    public class AutoWireComponentsInToThe : IStartupCommand
    {
        readonly DependencyRegistration registrar;
        readonly ComponentExclusionSpecification exclusion_policy;

        public AutoWireComponentsInToThe(DependencyRegistration registrar)
            : this(registrar, new ComponentExclusionSpecificationImplementation()) {}

        public AutoWireComponentsInToThe(DependencyRegistration registration,
                                         ComponentExclusionSpecification exclusion_policy)
        {
            registrar = registration;
            this.exclusion_policy = exclusion_policy;
        }

        public void run_against(Assembly item)
        {
            item
                .all_types(exclusion_policy.not())
                .each(x => add_registration_for(x));
        }

        void add_registration_for(Type type)
        {
            if (type.GetInterfaces().Length > 0) registrar.transient(type.first_interface(), type);
            else registrar.transient(type, type);
        }
    }
}