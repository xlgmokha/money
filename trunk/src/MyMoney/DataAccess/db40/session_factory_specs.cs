using Db4objects.Db4o;
using jpboodhoo.bdd.contexts;
using MyMoney.Presentation.Model.Projects;
using MyMoney.Testing.Extensions;
using MyMoney.Testing.MetaData;
using MyMoney.Testing.spechelpers.contexts;
using mocking_extensions=MyMoney.Testing.spechelpers.core.mocking_extensions;

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

                    mocking_extensions.it_will_return(mocking_extensions.is_told_to(database_configuration, x => x.path_to_the_database()), the_path_to_the_database_file);
                    mocking_extensions.it_will_return(mocking_extensions.is_told_to(connection_factory, x => x.open_connection_to(the_path_to_the_database_file)), session);
                };

        because b = () => { result = sut.create(); };

        static IObjectContainer result;
        static IObjectContainer session;
    }

    public class when_creating_a_session_for_a_file_that_has_already_been_opened : behaves_like_a_session_factory
    {
        it should_only_open_the_connection_once =
            () => mocking_extensions.was_told_to(connection_factory, x => x.open_connection_to(the_path_to_the_database_file)).only_once();

        it should_return_the_original_connection = () => result.should_be_equal_to(original_connection);

        context c = () =>
                        {
                            the_path_to_the_database_file = an<IFile>();
                            original_connection = an<IObjectContainer>();

                            mocking_extensions.it_will_return(mocking_extensions.is_told_to(when_the(database_configuration), x => x.path_to_the_database()), the_path_to_the_database_file);

                            mocking_extensions.it_will_return(mocking_extensions.is_told_to(when_the(connection_factory), x => x.open_connection_to(the_path_to_the_database_file)), original_connection);
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
        it should_close_the_previous_file = () => mocking_extensions.was_told_to(original_connection, x => x.Close()).only_once();

        context c = () =>
                        {
                            var the_path_to_the_database_file = an<IFile>();
                            var a_new_path = an<IFile>();
                            original_connection = an<IObjectContainer>();

                            mocking_extensions.it_will_return(mocking_extensions.is_told_to(database_configuration, x => x.path_to_the_database()), the_path_to_the_database_file)
                                .Repeat.Once();

                            mocking_extensions.it_will_return(mocking_extensions.is_told_to(database_configuration, x => x.path_to_the_database()), a_new_path)
                                .Repeat.Once();

                            mocking_extensions.it_will_return(mocking_extensions.is_told_to(connection_factory, x => x.open_connection_to(the_path_to_the_database_file)), original_connection);
                        };

        because b = () =>
                        {
                            sut.create();
                            sut.create();
                        };

        static IObjectContainer original_connection;
    }
}