using System.Collections;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;

namespace MoMoney.DataAccess.Transactions
{
    public class PerThreadScopedStorageSpecs
    {

    [Concern(typeof (PerThreadScopedStorage))]
    public class when_retrieving_the_storage_for_a_specific_thread :
        concerns_for<IScopedStorage, PerThreadScopedStorage>
    {
        context c = () =>
        {
            thread = the_dependency<IThread>();
            storage = new Hashtable();
            when_the(thread)
                .is_told_to(x => x.provide_slot_for<Hashtable>())
                .it_will_return(storage);
        };

        because b = () => { result = sut.provide_storage(); };

        it should_return_the_storage_the_corresponds_to_the_current_thread = () => result.should_be_equal_to(storage);

        static IDictionary result;
        static IThread thread;
        static Hashtable storage;
    }
    }
}