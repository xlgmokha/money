using System;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using gorilla.commons.utility;

namespace momoney.database.transactions
{
    public class ChangeTrackerFactorySpecs {}

    [Concern(typeof (ChangeTrackerFactory))]
    public class when_creating_a_change_tracker_for_an_item : concerns_for<IChangeTrackerFactory, ChangeTrackerFactory>
    {
        it should_return_a_new_tracker = () => result.should_not_be_null();

        because b = () =>
        {
            result = sut.create_for<Identifiable<Guid>>();
        };

        static IChangeTracker<Identifiable<Guid>> result;
    }
}