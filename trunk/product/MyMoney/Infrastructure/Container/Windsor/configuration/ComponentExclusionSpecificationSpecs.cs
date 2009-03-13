using System.Windows.Forms;
using bdddoc.domain;
using developwithpassion.bdd.concerns;
using developwithpassion.bdd.contexts;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.Infrastructure.Container.Windsor.configuration
{
    public abstract class behaves_like_component_exclusion_specification :
        concerns_for<IComponentExclusionSpecification, ComponentExclusionSpecification>
    {
    }

    public class when_checking_if_a_windows_form_should_be_excluded : behaves_like_component_exclusion_specification
    {
        it should_be_excluded = () => result.should_be_true();

        because b = () => { result = sut.is_satisfied_by(typeof (Form)); };

        static bool result;
    }

    public class when_checking_if_a_dependency_registry_should_be_excluded :
        behaves_like_component_exclusion_specification
    {
        it should_be_excluded = () => result.should_be_true();

        because b = () => { result = sut.is_satisfied_by(typeof (IDependencyRegistry)); };

        static bool result;
    }

    //public class when_checking_if_a_set_of_observations_should_be_excluded : behaves_like_component_exclusion_specification
    //{
    //    it should_be_excluded = () => result.should_be_true();

    //    because b = () => { result = sut.is_satisfied_by(typeof (when_checking_if_a_set_of_observations_should_be_excluded)); };

    //    static bool result;
    //}
}