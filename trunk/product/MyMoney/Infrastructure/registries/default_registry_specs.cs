using System.Collections.Generic;
using jpboodhoo.bdd.contexts;
using MyMoney.Domain.Core;
using MyMoney.Infrastructure.Container;
using MyMoney.Testing.MetaData;
using MyMoney.Testing.spechelpers.contexts;
using assertion_extensions=MyMoney.Testing.spechelpers.core.assertion_extensions;
using mocking_extensions=MyMoney.Testing.spechelpers.core.mocking_extensions;

namespace MyMoney.Infrastructure.registries
{
    [Concern(typeof (default_registry<int>))]
    public class when_retrieving_all_the_items_from_the_default_repository :
        concerns_for<IRegistry<int>, default_registry<int>>
    {
        it should_leverage_the_resolver_to_retrieve_all_the_implementations =
            () => mocking_extensions.was_told_to(registry, r => r.all_the<int>());

        it should_return_the_items_resolved_by_the_registry = () => assertion_extensions.should_contain(result, 24);

        context c = () =>
                        {
                            var items_to_return = new List<int> {24};

                            registry = an<IDependencyRegistry>();
                            mocking_extensions.it_will_return(mocking_extensions.is_told_to(registry, r => r.all_the<int>()), items_to_return);
                        };

        public override IRegistry<int> create_sut()
        {
            return new default_registry<int>(registry);
        }

        because b = () => { result = sut.all(); };

        static IDependencyRegistry registry;
        static IEnumerable<int> result;
    }
}