using Db4objects.Db4o;
using Db4objects.Db4o.Events;
using MoMoney.Infrastructure.Extensions;
using MoMoney.Presentation.Model.Projects;

namespace MoMoney.Infrastructure.transactions2
{
    public interface IConnectionFactory
    {
        IObjectContainer open_connection_to(IFile the_path_to_the_database_file);
    }

    public class ConnectionFactory : IConnectionFactory
    {
        readonly IConfigureDatabaseStep setup;

        public ConnectionFactory(IConfigureDatabaseStep setup)
        {
            this.setup = setup;
        }

        public IObjectContainer open_connection_to(IFile the_path_to_the_database_file)
        {
            var configuration = Db4oFactory.NewConfiguration();
            setup.configure(configuration);

            var container = Db4oFactory.OpenFile(configuration, the_path_to_the_database_file.path);

            var registry = EventRegistryFactory.ForObjectContainer(container);
            registry.Creating += (sender, args) => this.log().debug("{0}", args.Object);
            registry.QueryStarted += (sender, args) => this.log().debug("{0}", args.Query);
            return container;
        }
    }
}