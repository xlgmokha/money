using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using MoMoney.Domain.Core;

namespace MoMoney.Infrastructure.Container.Windsor.configuration
{
    public abstract class behaves_like_component_exclusion_specification :
        concerns_for<IComponentExclusionSpecification, ComponentExclusionSpecification>
    {
    }

    public class when_checking_if_a_windows_form_should_be_excluded : behaves_like_component_exclusion_specification
    {
        it should_be_excluded = () => result.should_be_true();

        because b = () => { result = sut.is_satisfied_by(typeof (FakeForm)); };

        static bool result;
    }

    public class when_checking_if_a_dependency_registry_should_be_excluded :
        behaves_like_component_exclusion_specification
    {
        it should_be_excluded = () => result.should_be_true();

        because b = () => { result = sut.is_satisfied_by(typeof (FakeDependencyRegistry)); };

        static bool result;
    }

    public class when_checking_if_a_static_class_should_be_excluded : behaves_like_component_exclusion_specification
    {
        it should_be_excluded = () => result.should_be_true();

        because b = () => { result = sut.is_satisfied_by(typeof (FakeStaticClass)); };

        static bool result;
    }

    public class when_checking_if_an_domain_entity_should_be_excluded : behaves_like_component_exclusion_specification
    {
        it should_be_excluded = () => result.should_be_true();

        because b = () => { result = sut.is_satisfied_by(typeof (FakeEntity)); };

        static bool result;
    }

    public class when_checking_if_an_interface_should_be_excluded : behaves_like_component_exclusion_specification
    {
        it should_be_excluded = () => result.should_be_true();

        because b = () => { result = sut.is_satisfied_by(typeof (IDbConnection)); };

        static bool result;
    }


    //public class when_checking_if_a_set_of_observations_should_be_excluded : behaves_like_component_exclusion_specification
    //{
    //    it should_be_excluded = () => result.should_be_true();

    //    because b = () => { result = sut.is_satisfied_by(typeof (when_checking_if_a_set_of_observations_should_be_excluded)); };

    //    static bool result;
    //}
    public class FakeForm : Form
    {
    }

    public class FakeDependencyRegistry : IDependencyRegistry
    {
        public Interface get_a<Interface>()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Interface> all_the<Interface>()
        {
            throw new NotImplementedException();
        }
    }

    static public class FakeStaticClass
    {
    }

    public class FakeEntity : IEntity
    {
        public Guid id
        {
            get { throw new NotImplementedException(); }
        }
    }
}