using Castle.Core;
using Castle.Windsor;
using jpboodhoo.bdd.contexts;
using MyMoney.Testing.MetaData;
using MyMoney.Testing.spechelpers.contexts;
using MyMoney.Testing.spechelpers.core;
using mocking_extensions=MyMoney.Testing.spechelpers.core.mocking_extensions;

namespace MyMoney.Infrastructure.Container.Windsor
{
    [Concern(typeof (windsor_dependency_registry))]
    public class when_registering_a_singleton_component_with_the_windsor_container : concerns_for<IDependencyRegistry>
    {
        it should_return_the_same_instance_each_time_its_resolved =
            () => result.should_be_the_same_instance_as(sut.get_a<IBird>());

        it should_not_return_null = () => assertion_extensions.should_not_be_null(result);

        public override IDependencyRegistry create_sut()
        {
            return new windsor_dependency_registry();
        }

        because b = () => { result = sut.get_a<IBird>(); };

        static IBird result;
    }

    [Concern(typeof (windsor_dependency_registry))]
    public class when_creating_the_windsor_resolver_ : concerns_for<IDependencyRegistry>
    {
        it should_leverage_the_factory_to_create_the_underlying_container = () => mocking_extensions.was_told_to(factory, f => f.create());

        public override IDependencyRegistry create_sut()
        {
            return new windsor_dependency_registry(factory);
        }

        context c = () =>
                        {
                            var container = an<IWindsorContainer>();
                            factory = an<IWindsorContainerFactory>();
                            mocking_extensions.it_will_return(mocking_extensions.is_told_to(factory, f => f.create()), container);
                        };


        static IWindsorContainerFactory factory;
    }

    [Singleton]
    public class BlueBird : IBird
    {
    }

    public interface IBird
    {
    }
}