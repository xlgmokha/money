using System;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Infrastructure.Reflection;
using gorilla.commons.infrastructure.thirdparty;
using gorilla.commons.infrastructure.thirdparty.Castle.Windsor.Configuration;
using Gorilla.Commons.Testing;
using MbUnit.Framework;

namespace MoMoney.boot.container.registration
{
    [Ignore("I am not sure why but line 19 throws a BadImageFormatException")]
    public abstract class behaves_like_auto_registering_components_into_container :
        concerns_for<IStartupCommand, auto_wire_components_in_to_the>
    {
        context c = () =>
        {
            exclusions_criteria = the_dependency<ComponentExclusionSpecification>();
            builder = the_dependency<DependencyRegistration>();
        };

        public override IStartupCommand create_sut()
        {
            return new auto_wire_components_in_to_the(builder, exclusions_criteria);
        }

        static protected DependencyRegistration builder;
        static protected ComponentExclusionSpecification exclusions_criteria;
    }

    public class when_registering_all_the_components_from_an_assembly :
        behaves_like_auto_registering_components_into_container
    {
        it should_register_each_component_by_its_last_interface =
            () => builder.was_told_to(x => x.transient(interface_type, component_with_multiple_interfaces));

        it should_register_components_with_no_interface_by_their_actual_type =
            () => builder.was_told_to(x => x.transient(component_with_no_interface, component_with_no_interface));

        it should_not_register_components_that_violate_the_exclusion_policy =
            () => builder.was_not_told_to(x => x.transient(bad_type, bad_type));

        context c = () =>
        {
            assembly = an<Assembly>();
            interface_type = typeof (ITestComponent);
            component_with_multiple_interfaces = typeof (TestComponent);
            component_with_no_interface = typeof (ComponentNoInterface);
            bad_type = typeof (BadComponent);

            when_the(assembly).is_told_to(x => x.all_types())
                .it_will_return(component_with_multiple_interfaces, component_with_no_interface,
                                bad_type);
            when_the(exclusions_criteria).is_told_to(x => x.is_satisfied_by(bad_type))
                .it_will_return(false);
        };

        because b = () => sut.run(assembly);


        static Assembly assembly;
        static Type component_with_multiple_interfaces;
        static Type interface_type;
        static Type component_with_no_interface;
        static Type bad_type;
    }

    public interface IBaseComponent {}

    public interface ITestComponent {}

    public class BaseComponent : IBaseComponent {}

    public class TestComponent : BaseComponent, ITestComponent {}

    public class ComponentNoInterface {}

    public class BadComponent {}
}