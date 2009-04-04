using System;
using System.Reflection;
using MoMoney.Infrastructure.Container;
using MoMoney.Infrastructure.Container.Windsor.configuration;
using MoMoney.Infrastructure.reflection;
using MoMoney.Utility.Core;
using MoMoney.Utility.Extensions;

namespace MoMoney.boot.container.registration
{
    public interface IStartupCommand : ICommand, IParameterizedCommand<IAssembly>
    {
    }

    public class auto_wire_components_in_to_the : IStartupCommand
    {
        readonly IDependencyRegistration registrar;
        readonly IComponentExclusionSpecification exclusion_policy;

        public auto_wire_components_in_to_the(IDependencyRegistration registration,
                                              IComponentExclusionSpecification exclusion_policy)
        {
            registrar = registration;
            this.exclusion_policy = exclusion_policy;
        }

        public void run()
        {
            run(new ApplicationAssembly(Assembly.GetExecutingAssembly()));
        }

        public void run(IAssembly item)
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