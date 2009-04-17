using Gorilla.Commons.Utility.Core;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.boot.container.registration;
using MoMoney.Infrastructure.Container;
using MoMoney.Infrastructure.Container.Autofac;
using MoMoney.Infrastructure.Container.Windsor.configuration;

namespace MoMoney.boot.container
{
    internal class wire_up_the_container : ICommand
    {
        readonly IDependencyRegistration registry;
        readonly IComponentExclusionSpecification specification;

        public wire_up_the_container()
            : this(new AutofacDependencyRegistryBuilder(), new ComponentExclusionSpecification())
        {
        }

        public wire_up_the_container(IDependencyRegistration registry, IComponentExclusionSpecification specification)
        {
            this.registry = registry;
            this.specification = specification;
        }

        public void run()
        {
            new auto_wire_components_in_to_the(registry, specification)
                .then(new wire_up_the_essential_services_into_the(registry))
                .then(new wire_up_the_data_access_components_into_the(registry))
                .then(new wire_up_the_infrastructure_in_to_the(registry))
                .then(new wire_up_the_mappers_in_to_the(registry))
                .then(new wire_up_the_services_in_to_the(registry))
                .then(new wire_up_the_presentation_modules(registry))
                .then(new wire_up_the_views_in_to_the(registry))
                .then(new wire_up_the_reports_in_to_the(registry))
                .run();

            resolve.initialize_with(registry.build());
        }
    }
}