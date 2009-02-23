using System.Collections.Generic;
using jpboodhoo.bdd.contexts;
using MyMoney.Domain.Core;
using MyMoney.Infrastructure.Container;
using MyMoney.Testing.Extensions;
using MyMoney.Testing.MetaData;
using MyMoney.Testing.spechelpers.contexts;

namespace MyMoney.Infrastructure.registries
{
    [Concern(typeof (default_registry<int>))]
    public class when_retrieving_all_the_items_from_the_default_repository :
        concerns_for<IRegistry<int>, default_registry<int>>
    {
        it should_leverage_the_resolver_to_retrieve_all_the_implementations =
            () => registry.was_told_to(r => r.all_implementations_of<int>());

        it should_return_the_items_resolved_by_the_registry = () => result.should_contain(24);

        context c = () =>
                        {
                            var items_to_return = new List<int> {24};

                            registry = an<IDependencyRegistry>();
                            registry.is_told_to(r => r.all_implementations_of<int>()).it_will_return(items_to_return);
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