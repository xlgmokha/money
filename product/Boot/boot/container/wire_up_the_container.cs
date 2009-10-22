using Gorilla.Commons.Infrastructure.Container;
using gorilla.commons.infrastructure.thirdparty;
using gorilla.commons.infrastructure.thirdparty.Autofac;
using gorilla.commons.utility;
using MoMoney.boot.container.registration;

namespace MoMoney.boot.container
{
    class wire_up_the_container : Command
    {
        readonly DependencyRegistration registry;

        public wire_up_the_container() : this(new AutofacDependencyRegistryBuilder()) {}

        public wire_up_the_container(DependencyRegistration registry)
        {
            this.registry = registry;
        }

        public void run()
        {
            new auto_wire_components_in_to_the(registry)
                .then(new wire_up_the_essential_services_into_the(registry))
                .then(new wire_up_the_data_access_components_into_the(registry))
                .then(new wire_up_the_infrastructure_in_to_the(registry))
                .then(new wire_up_the_mappers_in_to_the(registry))
                .then(new wire_up_the_services_in_to_the(registry))
                .then(new wire_up_the_presentation_modules(registry))
                .then(new wire_up_the_views_in_to_the(registry))
                .then(new wire_up_the_reports_in_to_the(registry))
                .run();

            Resolve.initialize_with(registry.build());
        }
    }
}