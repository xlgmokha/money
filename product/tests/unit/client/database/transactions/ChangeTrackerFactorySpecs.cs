using System;
using gorilla.commons.utility;
using momoney.database.transactions;

namespace tests.unit.client.database.transactions
{
    public class ChangeTrackerFactorySpecs
    {
        [Concern(typeof (ChangeTrackerFactory))]
        public class when_creating_a_change_tracker_for_an_item : runner<ChangeTrackerFactory>
        {
            it should_return_a_new_tracker = () => result.should_not_be_null();

            because b = () =>
            {
                result = sut.create_for<Identifiable<Guid>>();
            };

            static IChangeTracker<Identifiable<Guid>> result;
        }
    }
}