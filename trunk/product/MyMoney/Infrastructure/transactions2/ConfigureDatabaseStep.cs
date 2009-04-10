using Db4objects.Db4o.Config;
using MoMoney.Utility.Core;

namespace MoMoney.Infrastructure.transactions2
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