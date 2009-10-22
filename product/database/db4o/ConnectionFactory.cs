using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using Gorilla.Commons.Infrastructure.FileSystem;
using gorilla.commons.utility;
using momoney.database.transactions;

namespace momoney.database.db4o
{
    public class ConnectionFactory : IConnectionFactory
    {
        readonly IConfigureDatabaseStep setup;
        readonly IConfigureObjectContainerStep setup_container;

        public ConnectionFactory(IConfigureDatabaseStep setup, IConfigureObjectContainerStep setup_container)
        {
            this.setup = setup;
            this.setup_container = setup_container;
        }

        public IDatabaseConnection open_connection_to(File the_path_to_the_database_file)
        {
            var configuration = Db4oFactory.NewConfiguration();
            setup.configure(configuration);
            return new DatabaseConnection(get_container(the_path_to_the_database_file, configuration));
        }

        IObjectContainer get_container(File the_path_to_the_database_file, IConfiguration configuration)
        {
            return Db4oFactory
                .OpenFile(configuration, the_path_to_the_database_file.path)
                .and_configure_with(setup_container);
        }
    }
}