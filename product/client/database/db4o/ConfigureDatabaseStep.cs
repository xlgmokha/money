using Db4objects.Db4o.Config;
using gorilla.commons.utility;

namespace momoney.database.db4o
{
    public interface IConfigureDatabaseStep : Configuration<IConfiguration> {}

    public class ConfigureDatabaseStep : IConfigureDatabaseStep
    {
        public void configure(IConfiguration item)
        {
            item.LockDatabaseFile(false);
            //item.UpdateDepth(10);
            //item.WeakReferences(true);
            //item.AutomaticShutDown(true);
        }
    }
}