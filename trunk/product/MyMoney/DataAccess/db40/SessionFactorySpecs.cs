using Db4objects.Db4o;
using developwithpassion.bdd.contexts;
using MoMoney.DataAccess.db40;
using MoMoney.Presentation.Model.Projects;
using MoMoney.Testing.MetaData;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.DataAccess.db40
{
    [Concern(typeof (SessionFactory))]
    public abstract class behaves_like_a_session_factory : concerns_for<ISessionFactory, SessionFactory>
    {
        //public override ISessionFactory create_sut()
        //{
        //    return new SessionFactory(database_configuration, connection_factory);
        //}

        context c = () =>
                        {
                            connection_factory = the_dependency<IConnectionFactory>();
                            database_configuration = the_dependency<IDatabaseConfiguration>();
                        };

        protected static IConnectionFactory connection_factory;
        protected static IDatabaseConfiguration database_configuration;
    }

    public class when_creating_a_new_session_to_a_db40_database : behaves_like_a_session_factory
    {
        it should_open_a_new_connection_to_the_database = () => result.should_be_equal_to(session);

        context c =
            () =>
                {
                    var the_path_to_the_database_file = an<IFile>();
                    session = an<IObjectContainer>();

                    database_configuration.is_told_to(x => x.path_to_the_database()).it_will_return( the_path_to_the_database_file);
                    connection_factory.is_told_to(x => x.open_connection_to(the_path_to_the_database_file)). it_will_return(session);
                };

        because b = () => { result = sut.create(); };

        static IObjectContainer result;
        static IObjectContainer session;
    }
}