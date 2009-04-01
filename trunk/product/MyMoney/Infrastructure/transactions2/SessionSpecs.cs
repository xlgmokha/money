using System;
using System.Collections.Generic;
using developwithpassion.bdd.contexts;
using MoMoney.Domain.Core;
using MoMoney.Infrastructure.caching;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.Infrastructure.transactions2
{
    public class SessionSpecs
    {
    }

    public class behaves_like_session : concerns_for<ISession, Session>
    {
        context c = () =>
                        {
                            factory = the_dependency<IIdentityMapFactory>();
                            transaction = the_dependency<ITransaction>();
                        };

        protected static IIdentityMapFactory factory;
        protected static ITransaction transaction;
    }

    public class when_saving_a_transient_item_to_a_session : behaves_like_session
    {
        it should_add_the_entity_to_the_identity_map = () => map.was_told_to(x => x.add(guid, entity));

        it should_add_the_item_to_the_current_transaction = () => transaction.was_told_to(x => x.add_transient(entity));

        context c = () =>
                        {
                            guid = Guid.NewGuid();
                            entity = an<ITestEntity>();
                            map = an<IIdentityMap<Guid, ITestEntity>>();

                            when_the(entity).is_told_to(x => x.Id).it_will_return(guid);
                            when_the(factory).is_told_to(x => x.create_for<ITestEntity>()).it_will_return(map);
                        };

        because b = () => sut.save(entity);

        static ITestEntity entity;
        static IIdentityMap<Guid, ITestEntity> map;
        static Guid guid;
    }

    public class when_commiting_the_changes_made_in_a_session : behaves_like_session
    {
        it should_commit_all_the_changes_from_the_running_transaction =
            () => transaction.was_told_to(x => x.commit_changes());

        it should_not_rollback_any_changes_from_the_running_transaction =
            () => transaction.was_not_told_to(x => x.rollback_changes());

        because b = () =>
                        {
                            sut.flush();
                            sut.Dispose();
                        };
    }

    public class when_closing_a_session_before_flushing_the_changes : behaves_like_session
    {
        it should_rollback_any_changes_made_in_the_current_transaction =
            () => transaction.was_told_to(x => x.rollback_changes());

        because b = () => sut.Dispose();
    }

    public class when_retrieving_an_all_the_items_from_a_session_it_retrieve_all_the_items_from_the_cache :
        behaves_like_session
    {
        it should_return_all_the_items_currently_loaded_in_the_cache = () => results.should_contain(entity);

        it should_load_all_the_items_from_the_database = () =>
                                                             {
                                                                 ///?how
                                                             };

        context c = () => {
                            guid = Guid.NewGuid();
                            entity = an<ITestEntity>();
                            map = an<IIdentityMap<Guid, ITestEntity>>();

                            when_the(entity).is_told_to(x => x.Id).it_will_return(guid);
                            when_the(factory).is_told_to(x => x.create_for<ITestEntity>()).it_will_return(map);
                            when_the(map).is_told_to(x => x.all()).it_will_return(entity);
        };

        because b = () =>
                        {
                            sut.save(entity);
                            results = sut.all<ITestEntity>();
                        };

        static IEnumerable<ITestEntity> results;
        static ITestEntity entity;
        static Guid guid;
        static IIdentityMap<Guid, ITestEntity> map;
    }


    public interface ITestEntity : IEntity
    {
    }
}