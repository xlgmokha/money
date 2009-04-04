using System;
using developwithpassion.bdd.contexts;
using MoMoney.Domain.Core;
using MoMoney.Infrastructure.Logging;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.Infrastructure.transactions2
{
    public class TransactionSpecs
    {
    }

    public class behaves_like_transaction : concerns_for<ITransaction, Transaction>
    {
        context c = () =>
                        {
                            registry = the_dependency<IStatementRegistry>();
                            database = the_dependency<IDatabase>();
                            factory = the_dependency<IChangeTrackerFactory>();
                        };

        protected static IStatementRegistry registry;
        protected static IDatabase database;
        protected static IChangeTrackerFactory factory;
    }

    public class when_creating_an_identity_map_for_a_specific_entity : behaves_like_transaction
    {
        it should_return_a_new_identity_map = () => result.should_not_be_null();

        because b = () => { result = sut.create_for<IEntity>(); };

        static IIdentityMap<Guid, IEntity> result;
    }

    public class when_commiting_a_set_of_transient_instances_to_the_database : behaves_like_transaction
    {
        it should_prepare_an_insert_command_for_each_transient_instance =
            () => registry.was_told_to(x => x.prepare_insert_statement_for(entity));

        it should_apply_the_insert_statement_against_the_database_for_each_entity =
            () => database.was_told_to(x => x.apply(insert_statement));

        context c = () =>
                        {
                            entity = an<IEntity>();
                            insert_statement = an<IStatement>();
                            when_the(registry)
                                .is_told_to(x => x.prepare_insert_statement_for(entity))
                                .it_will_return(insert_statement);
                        };

        because b = () =>
                        {
                            sut.add_transient(entity);
                            sut.commit_changes();
                        };

        static IEntity entity;
        static IStatement insert_statement;
    }

    public class when_commiting_a_set_of_dirty_instances_to_The_database : behaves_like_transaction
    {
        it should_prepare_an_update_command_for_each_transient_instance =
            () => registry.was_told_to(x => x.prepare_update_statement_for(entity)).only_once();

        it should_apply_the_update_statement_against_the_database_for_each_entity =
            () => database.was_told_to(x => x.apply(update_statement)).only_once();

        it should_not_throw_an_exception = () => exception_thrown_while_the_sut_performed_its_work.should_be_null();

        context c =
            () =>
                {
                    entity = an<IEntity>();
                    update_statement = an<IStatement>();

                    Log.For(entity).debug("context");
                    when_the(registry).is_told_to(x => x.prepare_update_statement_for(entity)).it_will_return( update_statement).Repeat.Any();
                };

        because b =
            () =>
                {
                    Log.For(entity).debug("because");
                    sut.add_dirty(entity);
                    sut.commit_changes();
                };

        static IEntity entity;
        static IStatement update_statement;
    }

    public class when_committing_a_transaction_and_an_item_in_the_identity_map_has_changed : behaves_like_transaction
    {
        it should_commit_the_changes_to_that_item = () => tracker.was_told_to(x => x.commit_to(database));

        context c = () =>
                        {
                            movie = new Movie("Goldeneye");
                            update_statement = an<IStatement>();
                            tracker = an<IChangeTracker<IMovie>>();

                            when_the(registry)
                                .is_told_to(x => x.prepare_update_statement_for(movie))
                                .it_will_return(update_statement);
                            when_the(factory).is_told_to(x => x.create_for<IMovie>()).it_will_return(tracker);
                            when_the(tracker).is_told_to(x => x.is_dirty()).it_will_return(true);
                        };


        because b = () =>
                        {
                            sut.create_for<IMovie>().add(movie.Id, movie);
                            movie.change_name_to("Austin Powers");
                            sut.commit_changes();
                        };

        static IStatement update_statement;
        static IMovie movie;
        static IChangeTracker<IMovie> tracker;
    }

    public class when_deleting_a_set_of_entities_from_the_database : behaves_like_transaction
    {
        it should_apply_a_deletion_statement_for_each_entity =
            () => database.was_told_to(x => x.apply(deletion_statement));

        context c = () =>
                        {
                            entity = an<IEntity>();
                            deletion_statement = an<IStatement>();
                            when_the(registry)
                                .is_told_to(x => x.prepare_delete_statement_for(entity))
                                .it_will_return(deletion_statement);
                        };

        after_the_sut_has_been_created after_sut = () => sut.mark_for_deletion(entity);

        because b = () => sut.commit_changes();

        static IEntity entity;
        static IStatement deletion_statement;
    }

    public interface IMovie : IEntity
    {
        string name { get; }
        void change_name_to(string name);
    }

    internal class Movie : IMovie
    {
        public Movie(string name)
        {
            Id = Guid.NewGuid();
            this.name = name;
        }

        public string name { get; set; }

        public void change_name_to(string new_name)
        {
            name = new_name;
        }

        public Guid Id { get; set; }
    }
}