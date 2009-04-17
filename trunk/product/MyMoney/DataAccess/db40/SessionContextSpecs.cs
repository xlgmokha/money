using Db4objects.Db4o;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using MoMoney.Presentation.Model.Projects;

namespace MoMoney.DataAccess.db40
{
    [Concern(typeof (SessionContext))]
    public abstract class behaves_like_a_session_factory : concerns_for<ISessionContext, SessionContext>
    {
        context c = () =>
                        {
                            connection_factory = the_dependency<IConnectionFactory>();
                        };

        protected static IConnectionFactory connection_factory;
    }

    public class when_creating_a_new_session_to_a_db40_database : behaves_like_a_session_factory
    {
        it should_open_a_new_connection_to_the_database = () => result.should_be_an_instance_of<ISession>();

        context c =
            () =>
                {
                    var the_path_to_the_database_file = an<IFile>();
                    session = an<IObjectContainer>();

                    connection_factory.is_told_to(x => x.open_connection_to(the_path_to_the_database_file)). it_will_return(session);
                };

        because b = () => { result = sut.current_session(); };

        static ISession result;
        static IObjectContainer session;
    }
}