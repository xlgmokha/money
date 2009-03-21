using System;
using System.Linq;
using System.Reflection;
using MoMoney.boot.container.registration;
using MoMoney.Infrastructure.Container.Windsor;
using MoMoney.Infrastructure.Container.Windsor.configuration;
using MoMoney.Utility.Core;
using MoMoney.Utility.Extensions;

namespace MoMoney.boot.container
{
    internal class wire_up_the_container : ICommand
    {
        public void run()
        {
            var container = new WindsorContainerFactory().create();
            var registry = new WindsorDependencyRegistry(container);
            //var registry = new AutofacDependencyRegistry();
            var specification = new ComponentExclusionSpecification();
            var configuration = new ComponentRegistrationConfiguration();

            new wire_up_the_essential_services_into_the(registry)
                .then(new wire_up_the_data_access_components_into_the(registry))
                .then(new wire_up_the_infrastructure_in_to_the(registry))
                .then(new wire_up_the_mappers_in_to_the(registry))
                .then(new wire_up_the_views_in_to_the(registry))
                .then(new wire_up_the_presentation_modules(registry))
                .then(new wire_up_the_reports_in_to_the(registry))
                .then(new run_mass_component_registration_in_to_the(container, specification, configuration))
                //.then(new auto_wire_components_in_to_the(registry, specification))
                .run();
        }
    }

    internal class auto_wire_components_in_to_the : ICommand
    {
        readonly IContainerBuilder builder;
        readonly IComponentExclusionSpecification specification;

        public auto_wire_components_in_to_the(IContainerBuilder builder,
                                              IComponentExclusionSpecification specification)
        {
            this.builder = builder;
            this.specification = specification;
        }

        public void run()
        {
            Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x => !specification.is_satisfied_by(x))
                .each(register);
        }

        void register(Type type)
        {
            if (type.GetInterfaces().Length > 0)
            {
                //if (typeof(ILoggable).IsAssignableFrom(type))
                {
                    //builder.proxy(h
                }
                //else
                {
                    builder.transient(type.last_interface(), type);
                }
            }
            else
            {
                builder.transient(type, type);
            }
        }
    }
}