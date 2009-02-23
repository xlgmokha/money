using System;
using Castle.Core;
using Db4objects.Db4o;
using MyMoney.Presentation.Model.Projects;
using MyMoney.Utility.Core;

namespace MyMoney.DataAccess.db40
{
    public interface ISessionFactory : IFactory<IObjectContainer>
    {
    }

    [Singleton]
    public class session_factory : ISessionFactory, IDisposable
    {
        readonly IDatabaseConfiguration database_configuration;
        readonly IConnectionFactory connection_factory;
        IFile currently_opened_database_file;
        IObjectContainer opened_connection;

        public session_factory(IDatabaseConfiguration database_configuration, IConnectionFactory connection_factory)
        {
            this.database_configuration = database_configuration;
            this.connection_factory = connection_factory;
        }

        public IObjectContainer create()
        {
            var path_to_the_database = database_configuration.path_to_the_database();
            if (path_to_the_database.Equals(currently_opened_database_file))
            {
                return opened_connection;
            }
            return open_connection_to(path_to_the_database);
        }

        IObjectContainer open_connection_to(IFile path_to_the_database)
        {
            close_the_current_connection();
            currently_opened_database_file = path_to_the_database;
            opened_connection = connection_factory.open_connection_to(currently_opened_database_file);
            return opened_connection;
        }

        public void Dispose()
        {
            close_the_current_connection();
        }

        void close_the_current_connection()
        {
            if (null == opened_connection) return;
            opened_connection.Close();
            opened_connection.Dispose();
        }
    }
}