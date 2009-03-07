using Castle.Core;
using Castle.Windsor;
using jpboodhoo.bdd.contexts;
using MoMoney.Testing.MetaData;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.Infrastructure.Container.Windsor
{
    [Concern(typeof (WindsorDependencyRegistry))]
    public class when_registering_a_singleton_component_with_the_windsor_container : concerns_for<IDependencyRegistry>
    {
        it should_return_the_same_instance_each_time_its_resolved =
            () => result.should_be_the_same_instance_as(sut.get_a<IBird>());

        it should_not_return_null = () => result.should_not_be_null();

        public override IDependencyRegistry create_sut()
        {
            return new WindsorDependencyRegistry();
        }

        because b = () => { result = sut.get_a<IBird>(); };

        static IBird result;
    }

    [Concern(typeof (WindsorDependencyRegistry))]
    public class when_creating_the_windsor_resolver_ : concerns_for<IDependencyRegistry>
    {
        it should_leverage_the_factory_to_create_the_underlying_container = () => factory.was_told_to(f => f.create());

        public override IDependencyRegistry create_sut()
        {
            return new WindsorDependencyRegistry(factory);
        }

        context c = () =>
                        {
                            var container = an<IWindsorContainer>();
                            factory = an<IWindsorContainerFactory>();
                            factory.is_told_to(f => f.create()).it_will_return(container);
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