using System.Collections.Generic;
using jpboodhoo.bdd.contexts;
using MoMoney.Domain.Core;
using MoMoney.Infrastructure.Container;
using MoMoney.Testing.MetaData;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.Infrastructure.registries
{
    [Concern(typeof (default_registry<int>))]
    public class when_retrieving_all_the_items_from_the_default_repository :
        concerns_for<IRegistry<int>, default_registry<int>>
    {
        it should_leverage_the_resolver_to_retrieve_all_the_implementations =
            () => registry.was_told_to(r => r.all_the<int>());

        it should_return_the_items_resolved_by_the_registry = () => result.should_contain(24);

        context c = () =>
                        {
                            var items_to_return = new List<int> {24};
                            registry = an<IDependencyRegistry>();
                            registry.is_told_to(r => r.all_the<int>()).it_will_return(items_to_return);
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