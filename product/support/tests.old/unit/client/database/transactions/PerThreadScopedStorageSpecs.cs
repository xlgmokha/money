using System.Collections;
using momoney.database.transactions;

namespace tests.unit.client.database.transactions
{
    public class PerThreadScopedStorageSpecs
    {
        [Concern(typeof (PerThreadScopedStorage))]
        public class when_retrieving_the_storage_for_a_specific_thread : runner<PerThreadScopedStorage>
        {
            context c = () =>
            {
                thread = dependency<IThread>();
                storage = new Hashtable();
                thread
                    .is_told_to(x => x.provide_slot_for<Hashtable>())
                    .it_will_return(storage);
            };

            because b = () =>
            {
                result = sut.provide_storage();
            };

            it should_return_the_storage_the_corresponds_to_the_current_thread = () => result.should_be_equal_to(storage);

            static IDictionary result;
            static IThread thread;
            static Hashtable storage;
        }
    }
}