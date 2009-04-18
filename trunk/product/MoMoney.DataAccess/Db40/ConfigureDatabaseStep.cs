using Db4objects.Db4o.Config;
using Gorilla.Commons.Utility.Core;

namespace MoMoney.DataAccess.Db40
{
    public interface IConfigureDatabaseStep : IConfiguration<IConfiguration>
    {
    }

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