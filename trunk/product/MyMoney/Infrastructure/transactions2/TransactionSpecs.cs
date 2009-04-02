using System;
using developwithpassion.bdd.contexts;
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
                        };

        protected static IStatementRegistry registry;
        protected static IDatabase database;
    }

    public class when_creating_an_identity_map_for_a_specific_entity : behaves_like_transaction
    {
        it should_return_a_new_identity_map = () => result.should_not_be_null();

        because b = () => { result = sut.create_for<ITestEntity>(); };

        static IIdentityMap<Guid, ITestEntity> result;
    }

    public class when_commiting_a_set_of_transient_instances_to_The_database : behaves_like_transaction
    {
        it should_prepare_an_insert_command_for_each_transient_instance =
            () => registry.was_told_to(x => x.prepare_insert_statement_for(entity));

        it should_apply_the_insert_statement_against_the_database_for_each_entity =
            () => database.was_told_to(x => x.apply(insert_statement));

        context c = () =>
                        {
                            entity = an<ITestEntity>();
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

        static ITestEntity entity;
        static IStatement insert_statement;
    }

    public class when_commiting_a_set_of_dirty_instances_to_The_database : behaves_like_transaction
    {
        it should_prepare_an_insert_command_for_each_transient_instance =
            () => registry.was_told_to(x => x.prepare_update_statement_for(entity));

        it should_apply_the_insert_statement_against_the_database_for_each_entity =
            () => database.was_told_to(x => x.apply(update_statement));

        context c = () =>
                        {
                            entity = an<ITestEntity>();
                            update_statement = an<IStatement>();
                            when_the(registry)
                                .is_told_to(x => x.prepare_update_statement_for(entity))
                                .it_will_return(update_statement);
                        };

        because b = () =>
                        {
                            sut.add_dirty(entity);
                            sut.commit_changes();
                        };

        static ITestEntity entity;
        static IStatement update_statement;
    }
}