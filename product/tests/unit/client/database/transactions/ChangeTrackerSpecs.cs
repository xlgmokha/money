using System;
using developwithpassion.bdd.contexts;
using gorilla.commons.utility;
using momoney.database.transactions;

namespace tests.unit.client.database.transactions
{
    public class ChangeTrackerSpecs
    {

        [Concern(typeof (ChangeTracker<Identifiable<Guid>>))]
        public abstract class behaves_like_change_tracker :
            concerns_for<IChangeTracker<Identifiable<Guid>>, ChangeTracker<Identifiable<Guid>>>
        {
            context c = () =>
            {
                mapper = the_dependency<ITrackerEntryMapper<Identifiable<Guid>>>();
                registry = the_dependency<DatabaseCommandRegistry>();
            };

            static protected ITrackerEntryMapper<Identifiable<Guid>> mapper;
            static protected DatabaseCommandRegistry registry;
        }

        [Concern(typeof (ChangeTracker<Identifiable<Guid>>))]
        public class when_commit_that_changes_made_to_an_item : behaves_like_change_tracker
        {
            it should_save_the_changes_to_the_database = () => database.was_told_to(x => x.apply(statement));

            context c = () =>
            {
                item = an<Identifiable<Guid>>();
                statement = an<DatabaseCommand>();
                database = an<IDatabase>();
                var entry = an<ITrackerEntry<Identifiable<Guid>>>();

                when_the(mapper).is_told_to(x => x.map_from(item)).it_will_return(entry);
                when_the(entry).is_told_to(x => x.has_changes()).it_will_return(true);
                when_the(entry).is_told_to(x => x.current).it_will_return(item);
                when_the(registry).is_told_to(x => x.prepare_for_flushing(item)).it_will_return(statement);
            };

            because b = () =>
            {
                sut.register(item);
                sut.commit_to(database);
            };

            static Identifiable<Guid> item;
            static IDatabase database;
            static DatabaseCommand statement;
        }

        [Concern(typeof (ChangeTracker<Identifiable<Guid>>))]
        public class when_checking_if_there_are_changes_and_there_are : behaves_like_change_tracker
        {
            it should_tell_the_truth = () => result.should_be_true();

            context c = () =>
            {
                item = an<Identifiable<Guid>>();
                var registration = an<ITrackerEntry<Identifiable<Guid>>>();

                when_the(mapper).is_told_to(x => x.map_from(item)).it_will_return(registration);
                when_the(registration).is_told_to(x => x.has_changes()).it_will_return(true);
                when_the(registration).is_told_to(x => x.current).it_will_return(item);
            };

            because b = () =>
            {
                sut.register(item);
                result = sut.is_dirty();
            };

            static bool result;
            static Identifiable<Guid> item;
        }

        [Concern(typeof (ChangeTracker<Identifiable<Guid>>))]
        public class when_checking_if_there_are_changes_and_there_are_not : behaves_like_change_tracker
        {
            it should_tell_the_truth = () => result.should_be_false();

            context c = () =>
            {
                item = an<Identifiable<Guid>>();
                var entry = an<ITrackerEntry<Identifiable<Guid>>>();

                when_the(mapper).is_told_to(x => x.map_from(item)).it_will_return(entry);
                when_the(entry).is_told_to(x => x.has_changes()).it_will_return(false);
            };

            because b = () =>
            {
                sut.register(item);
                result = sut.is_dirty();
            };

            static bool result;
            static Identifiable<Guid> item;
        }
    }
}