using System;
using Castle.Windsor;
using MoMoney.Infrastructure.Container.Windsor;
using MoMoney.Infrastructure.Container.Windsor.configuration;
using MoMoney.Utility.Core;
using MoMoney.Utility.Extensions;
using MoMoney.windows.ui;

namespace MoMoney.boot.container
{
    internal class wire_up_the_container : ICommand
    {
        public void run()
        {
            Func<IWindsorContainer> container = () => new WindsorContainerFactory().create();
            container = container.memorize();

            var registry = new WindsorDependencyRegistry(container);
            var specification = new ComponentExclusionSpecification();
            var configuration = new ComponentRegistrationConfiguration();

            new wire_up_the_essential_services_into_the(registry)
                .then(new wire_up_the_mappers_in_to_the(registry))
                .then(new wire_up_the_views_in_to_the(registry))
                .then(new wire_up_the_reports_in_to_the(registry))
                .then(new run_mass_component_registration_in_to_the(container, specification, configuration))
                .run();
        }
    }
}