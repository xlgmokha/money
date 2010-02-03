using System;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using gorilla.commons.utility;

namespace momoney.database.transactions
{
    public class TransactionSpecs
    {
    }

    [Concern(typeof (Transaction))]
    public class behaves_like_transaction : concerns_for<ITransaction, Transaction>
    {
        context c = () =>
        {
            database = the_dependency<IDatabase>();
            factory = the_dependency<IChangeTrackerFactory>();
        };

        static protected IDatabase database;
        static protected IChangeTrackerFactory factory;
    }

    [Concern(typeof (Transaction))]
    public class when_creating_an_identity_map_for_a_specific_entity : behaves_like_transaction
    {
        it should_return_a_new_identity_map = () => result.should_not_be_null();

        because b = () => { result = sut.create_for<Identifiable<Guid>>(); };

        static IIdentityMap<Guid, Identifiable<Guid>> result;
    }

    [Concern(typeof (Transaction))]
    public class when_committing_a_transaction_and_an_item_in_the_identity_map_has_changed : behaves_like_transaction
    {
        it should_commit_the_changes_to_that_item =
            () => tracker.was_told_to(x => x.commit_to(database));

        context c = () =>
        {
            movie = new Movie("Goldeneye");
            tracker = an<IChangeTracker<IMovie>>();

            when_the(factory).is_told_to(x => x.create_for<IMovie>()).it_will_return(tracker);
            when_the(tracker).is_told_to(x => x.is_dirty()).it_will_return(true);
        };


        because b = () =>
        {
            sut.create_for<IMovie>().add(movie.id, movie);
            movie.change_name_to("Austin Powers");
            sut.commit_changes();
        };

        static IMovie movie;
        static IChangeTracker<IMovie> tracker;
    }

    [Concern(typeof (Transaction))]
    public class when_deleting_a_set_of_entities_from_the_database : behaves_like_transaction
    {
        it should_prepare_to_delete_that_item_form_the_database = () => tracker.was_told_to(x => x.delete(movie));

        it should_delete_all_items_marked_for_deletion = () => tracker.was_told_to(x => x.commit_to(database));

        context c = () =>
        {
            movie = new Movie("Goldeneye");
            tracker = an<IChangeTracker<IMovie>>();

            when_the(factory).is_told_to(x => x.create_for<IMovie>()).it_will_return(tracker);
            when_the(tracker).is_told_to(x => x.is_dirty()).it_will_return(true);
        };

        because b = () =>
        {
            var map = sut.create_for<IMovie>();
            map.add(movie.id, movie);
            map.evict(movie.id);
            sut.commit_changes();
        };

        static IMovie movie;
        static IChangeTracker<IMovie> tracker;
    }

    public interface IMovie : Identifiable<Guid>
    {
        string name { get; }
        void change_name_to(string name);
    }

    internal class Movie : IMovie
    {
        public Movie(string name)
        {
            id = Guid.NewGuid();
            this.name = name;
        }

        public string name { get; set; }

        public void change_name_to(string new_name)
        {
            name = new_name;
        }

        public Id<Guid> id { get; set; }
    }
}