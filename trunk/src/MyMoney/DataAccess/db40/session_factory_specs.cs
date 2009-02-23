using Db4objects.Db4o;
using jpboodhoo.bdd.contexts;
using MyMoney.Presentation.Model.Projects;
using MyMoney.Testing.Extensions;
using MyMoney.Testing.MetaData;

namespace MyMoney.DataAccess.db40
{
    [Concern(typeof (session_factory))]
    public abstract class behaves_like_a_session_factory : concerns_for<ISessionFactory, session_factory>
    {
        public override ISessionFactory create_sut()
        {
            return new session_factory(database_configuration, connection_factory);
        }

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

                    database_configuration
                        .is_told_to(x => x.path_to_the_database())
                        .it_will_return(the_path_to_the_database_file);
                    connection_factory
                        .is_told_to(x => x.open_connection_to(the_path_to_the_database_file))
                        .it_will_return(session);
                };

        because b = () => { result = sut.create(); };

        static IObjectContainer result;
        static IObjectContainer session;
    }

    public class when_creating_a_session_for_a_file_that_has_already_been_opened : behaves_like_a_session_factory
    {
        it should_only_open_the_connection_once =
            () => connection_factory.was_told_to(x => x.open_connection_to(the_path_to_the_database_file)).only_once();

        it should_return_the_original_connection = () => result.should_be_equal_to(original_connection);

        context c = () =>
                        {
                            the_path_to_the_database_file = an<IFile>();
                            original_connection = an<IObjectContainer>();

                            when_the(database_configuration)
                                .is_told_to(x => x.path_to_the_database())
                                .it_will_return(the_path_to_the_database_file);

                            when_the(connection_factory)
                                .is_told_to(x => x.open_connection_to(the_path_to_the_database_file))
                                .it_will_return(original_connection);
                        };

        because b = () =>
                        {
                            result = sut.create();
                            result = sut.create();
                        };

        static IFile the_path_to_the_database_file;
        static IObjectContainer result;
        static IObjectContainer original_connection;
    }

    public class when_opening_a_new_file_after_one_has_already_been_opened : behaves_like_a_session_factory
    {
        it should_close_the_previous_file = () => original_connection.was_told_to(x => x.Close()).only_once();

        context c = () =>
                        {
                            var the_path_to_the_database_file = an<IFile>();
                            var a_new_path = an<IFile>();
                            original_connection = an<IObjectContainer>();

                            database_configuration
                                .is_told_to(x => x.path_to_the_database())
                                .it_will_return(the_path_to_the_database_file)
                                .Repeat.Once();

                            database_configuration
                                .is_told_to(x => x.path_to_the_database())
                                .it_will_return(a_new_path)
                                .Repeat.Once();

                            connection_factory
                                .is_told_to(x => x.open_connection_to(the_path_to_the_database_file))
                                .it_will_return(original_connection);
                        };

        because b = () =>
                        {
                            sut.create();
                            sut.create();
                        };

        static IObjectContainer original_connection;
    }
}