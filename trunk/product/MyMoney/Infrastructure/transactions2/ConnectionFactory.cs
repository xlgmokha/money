using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using Db4objects.Db4o.Events;
using MoMoney.Infrastructure.Extensions;
using MoMoney.Presentation.Model.Projects;

namespace MoMoney.Infrastructure.transactions2
{
    public interface IConnectionFactory
    {
        IDatabaseConnection open_connection_to(IFile the_path_to_the_database_file);
    }

    public class ConnectionFactory : IConnectionFactory
    {
        readonly IConfigureDatabaseStep setup;

        public ConnectionFactory(IConfigureDatabaseStep setup)
        {
            this.setup = setup;
        }

        public IDatabaseConnection open_connection_to(IFile the_path_to_the_database_file)
        {
            var configuration = Db4oFactory.NewConfiguration();
            setup.configure(configuration);
            return new DatabaseConnection(get_container(the_path_to_the_database_file, configuration));
        }

        IObjectContainer get_container(IFile the_path_to_the_database_file, IConfiguration configuration)
        {
            var container = Db4oFactory.OpenFile(configuration, the_path_to_the_database_file.path);
            //var registry = EventRegistryFactory.ForObjectContainer(container);
            //registry.ClassRegistered +=
            //    (sender, args) => this.log().debug("class registered: {0}", args.ClassMetadata());
            //registry.Instantiated += (sender, args) => this.log().debug("class instantiated: {0}", args.Object.GetType().Name);
            //registry.Committed +=
            //    (sender, args) =>
            //    this.log().debug("added: {0}, updated: {1}, deleted: {2}", args.Added, args.Updated, args.Deleted);
            return container;
        }
    }
}