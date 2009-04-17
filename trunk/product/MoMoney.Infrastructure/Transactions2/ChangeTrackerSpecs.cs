using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using MoMoney.Domain.Core;

namespace MoMoney.Infrastructure.transactions2
{
    public class ChangeTrackerSpecs
    {
    }

    [Concern(typeof (ChangeTracker<IEntity>))]
    public abstract class behaves_like_change_tracker : concerns_for<IChangeTracker<IEntity>, ChangeTracker<IEntity>>
    {
        context c = () =>
                        {
                            mapper = the_dependency<ITrackerEntryMapper<IEntity>>();
                            registry = the_dependency<IStatementRegistry>();
                        };

        protected static ITrackerEntryMapper<IEntity> mapper;
        protected static IStatementRegistry registry;
    }

    public class when_commit_that_changes_made_to_an_item : behaves_like_change_tracker
    {
        it should_save_the_changes_to_the_database = () => database.was_told_to(x => x.apply(statement));

        context c = () =>
                        {
                            item = an<IEntity>();
                            statement = an<IStatement>();
                            database = an<IDatabase>();
                            var entry = an<ITrackerEntry<IEntity>>();

                            when_the(mapper).is_told_to(x => x.map_from(item)).it_will_return(entry);
                            when_the(entry).is_told_to(x => x.has_changes()).it_will_return(true);
                            when_the(entry).is_told_to(x => x.current).it_will_return(item);
                            when_the(registry).is_told_to(x => x.prepare_command_for(item)).it_will_return(statement);
                        };

        because b = () =>
                        {
                            sut.register(item);
                            sut.commit_to(database);
                        };

        static IEntity item;
        static IDatabase database;
        static IStatement statement;
    }

    public class when_checking_if_there_are_changes_and_there_are : behaves_like_change_tracker
    {
        it should_tell_the_truth = () => result.should_be_true();

        context c = () =>
                        {
                            item = an<IEntity>();
                            var registration = an<ITrackerEntry<IEntity>>();

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
        static IEntity item;
    }

    public class when_checking_if_there_are_changes_and_there_are_not : behaves_like_change_tracker
    {
        it should_tell_the_truth = () => result.should_be_false();

        context c = () =>
                        {
                            item = an<IEntity>();
                            var entry = an<ITrackerEntry<IEntity>>();

                            when_the(mapper).is_told_to(x => x.map_from(item)).it_will_return(entry);
                            when_the(entry).is_told_to(x => x.has_changes()).it_will_return(false);
                        };

        because b = () =>
                        {
                            sut.register(item);
                            result = sut.is_dirty();
                        };

        static bool result;
        static IEntity item;
    }
}