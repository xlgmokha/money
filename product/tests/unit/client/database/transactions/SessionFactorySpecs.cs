using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;

namespace momoney.database.transactions
{
    public class SessionFactorySpecs
    {
        [Concern(typeof (SessionFactory))]
        public class when_creating_a_new_session : concerns_for<ISessionFactory, SessionFactory>
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