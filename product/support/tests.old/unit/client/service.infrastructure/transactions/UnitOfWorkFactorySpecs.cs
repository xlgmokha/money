using momoney.database.transactions;
using momoney.service.infrastructure.transactions;
using MoMoney.Service.Infrastructure.Transactions;

namespace tests.unit.client.service.infrastructure.transactions
{
    public class UnitOfWorkFactorySpecs
    {
        [Concern(typeof (UnitOfWorkFactory))]
        public abstract class TestsForUnitOfWorkFactory : runner<UnitOfWorkFactory>
        {
            context c = () =>
            {
                session_context = dependency<IContext>();
                factory = dependency<ISessionFactory>();
                key = dependency<IKey<ISession>>();
            };

            static protected IContext session_context;
            static protected ISessionFactory factory;
            static protected IKey<ISession> key;
        }

        [Concern(typeof (UnitOfWorkFactory))]
        public class when_a_unit_of_work_has_not_been_started : TestsForUnitOfWorkFactory
        {
            context c = () =>
            {
                session_context.is_told_to(x => x.contains(key)).it_will_return(false);
            };
        }

        [Concern(typeof (UnitOfWorkFactory))]
        public class when_a_unit_of_work_has_been_started : TestsForUnitOfWorkFactory
        {
            context c = () =>
            {
                session_context.is_told_to(x => x.contains(key)).it_will_return(true);
            };
        }

        [Concern(typeof (UnitOfWorkFactory))]
        public class when_creating_a_new_unit_of_work : when_a_unit_of_work_has_not_been_started
        {
            context c = () =>
            {
                session = an<ISession>();
                factory.is_told_to(x => x.create()).it_will_return(session);
            };

            because b = () =>
            {
                result = sut.create();
            };

            it should_create_a_new_unit_of_work = () => factory.was_told_to(x => x.create());

            it should_add_the_session_to_the_current_context = () => session_context.was_told_to(x => x.add(key, session));

            it should_return_a_brand_new_unit_of_work = () =>
            {
                result.should_not_be_null();
                result.should_be_an_instance_of<UnitOfWork>();
            };

            static IUnitOfWork result;
            static ISession session;
        }

        [Concern(typeof (UnitOfWorkFactory))]
        public class when_attempting_to_create_a_new_unit_of_work : when_a_unit_of_work_has_been_started
        {
            because b = () =>
            {
                result = sut.create();
            };

            it should_not_create_a_new_unit_of_work = () => factory.was_not_told_to(x => x.create());

            it should_return_an_empty_unit_of_work = () =>
            {
                result.should_not_be_null();
                result.should_be_an_instance_of<EmptyUnitOfWork>();
            };

            static IUnitOfWork result;
        }
    }
}