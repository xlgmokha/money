using momoney.database.transactions;

namespace tests.unit.client.database.transactions
{
    public class SessionFactorySpecs
    {
        [Concern(typeof (SessionFactory))]
        public class when_creating_a_new_session : runner<SessionFactory>
        {
            it should_return_a_new_session = () => result.should_not_be_null();

            because b = () =>
            {
                result = sut.create();
            };

            static ISession result;
        }
    }
}