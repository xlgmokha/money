using Castle.Core;
using Castle.Windsor;
using MyMoney.Testing.Extensions;
using MyMoney.Testing.MetaData;

namespace MyMoney.Infrastructure.Container.Windsor
{
    public class windsor_dependency_registry_specs
    {}

    [Concern(typeof (windsor_dependency_registry))]
    public class when_registering_a_singleton_component_with_the_windsor_container : old_context_specification<IDependencyRegistry>
    {
        [Observation]
        public void should_return_the_same_instance_each_time_its_resolved()
        {
            result.should_be_the_same_instance_as(sut.find_an_implementation_of<IBird>());
        }

        [Observation]
        public void should_not_return_null()
        {
            result.should_not_be_null();
        }

        protected override IDependencyRegistry context()
        {
            return new windsor_dependency_registry();
        }

        protected override void because()
        {
            result = sut.find_an_implementation_of<IBird>();
        }

        private IBird result;
    }

    [Concern(typeof (windsor_dependency_registry))]
    public class when_creating_the_windsor_resolver_ : old_context_specification<IDependencyRegistry>
    {
        [Observation]
        public void should_leverage_the_factory_to_create_the_underlying_container()
        {
            factory.was_told_to(f => f.create());
        }

        protected override IDependencyRegistry context()
        {
            var container = an<IWindsorContainer>();
            factory = an<IWindsorContainerFactory>();
            factory.is_told_to(f => f.create()).Return(container);
            return new windsor_dependency_registry(factory);
        }

        protected override void because()
        {}

        private IWindsorContainerFactory factory;
    }

    [Singleton]
    public class BlueBird : IBird
    {}

    public interface IBird
    {}
}