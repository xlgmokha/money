using Db4objects.Db4o;
using Db4objects.Db4o.Events;
using Gorilla.Commons.Infrastructure.Logging;
using gorilla.commons.utility;

namespace momoney.database.db4o
{
    public interface IConfigureObjectContainerStep : Configuration<IObjectContainer> {}

    public class ConfigureObjectContainerStep : IConfigureObjectContainerStep
    {
        public void configure(IObjectContainer item)
        {
            var registry = EventRegistryFactory.ForObjectContainer(item);
            registry.ClassRegistered += (sender, args) => this.log().debug("class registered: {0}", args.ClassMetadata());
            registry.Instantiated += (sender, args) => this.log().debug("class instantiated: {0}", args.Object.GetType().Name);
            registry.Committed += (sender, args) => this.log().debug("added: {0}, updated: {1}, deleted: {2}", args.Added, args.Updated, args.Deleted);
        }
    }
}