using System;
using Gorilla.Commons.Infrastructure.Reflection;
using gorilla.commons.infrastructure.thirdparty;
using gorilla.commons.infrastructure.thirdparty.Castle.Windsor.Configuration;
using gorilla.commons.utility;

namespace MoMoney.boot.container.registration
{
    public class auto_wire_components_in_to_the : IStartupCommand
    {
        readonly DependencyRegistration registrar;
        readonly ComponentExclusionSpecification exclusion_policy;

        public auto_wire_components_in_to_the(DependencyRegistration registrar)
            : this(registrar, new ComponentExclusionSpecificationImplementation()) {}

        public auto_wire_components_in_to_the(DependencyRegistration registration,
                                              ComponentExclusionSpecification exclusion_policy)
        {
            registrar = registration;
            this.exclusion_policy = exclusion_policy;
        }

        public void run()
        {
            run(new ApplicationAssembly(System.Reflection.Assembly.GetExecutingAssembly()));
        }

        public void run(Assembly item)
        {
            item
                .all_types()
                .where(x => !exclusion_policy.is_satisfied_by(x))
                .each(x => add_registration_for(x));
        }

        void add_registration_for(Type type)
        {
            if (type.GetInterfaces().Length > 0) registrar.transient(type.first_interface(), type);
            else registrar.transient(type, type);
        }
    }
}