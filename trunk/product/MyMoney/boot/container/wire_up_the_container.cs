using System;
using Autofac;
using MoMoney.boot.container.registration;
using MoMoney.Infrastructure.Container;
using MoMoney.Infrastructure.Container.Autofac;
using MoMoney.Infrastructure.Container.Windsor.configuration;
using MoMoney.Utility.Core;
using MoMoney.Utility.Extensions;

namespace MoMoney.boot.container
{
    internal class wire_up_the_container : ICommand
    {
        public void run()
        {
            //var container = new WindsorContainerFactory().create();
            //var registry = new WindsorDependencyRegistry(container);
            var registry = new AutofacDependencyRegistryBuilder();
            var specification = new ComponentExclusionSpecification();
            var configuration = new ComponentRegistrationConfiguration();

            new wire_up_the_essential_services_into_the(registry)
                .then(new wire_up_the_data_access_components_into_the(registry))
                .then(new wire_up_the_infrastructure_in_to_the(registry))
                .then(new wire_up_the_mappers_in_to_the(registry))
                .then(new wire_up_the_services_in_to_the(registry))
                .then(new wire_up_the_presentation_modules(registry))
                .then(new wire_up_the_views_in_to_the(registry))
                .then(new wire_up_the_reports_in_to_the(registry))
                //.then(new run_mass_component_registration_in_to_the(container, specification, configuration))
                .then(new auto_wire_components_in_to_the(registry, specification))
                .run();

            Func<IContainer> func = registry.build;
            var dependency_registry = new AutofacDependencyRegistry(func.memorize());
            registry.singleton<IDependencyRegistry>(dependency_registry);
            resolve.initialize_with(dependency_registry);
        }
    }
}