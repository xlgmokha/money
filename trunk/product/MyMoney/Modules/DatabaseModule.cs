using MoMoney.Infrastructure.eventing;
using MoMoney.Infrastructure.transactions2;
using MoMoney.Modules.Core;

namespace MoMoney.Modules
{
    public interface IDatabaseModule : IModule
    {
    }

    public class DatabaseModule : IDatabaseModule
    {
        readonly IDatabaseConfiguration configuration;
        readonly IEventAggregator broker;

        public DatabaseModule(IDatabaseConfiguration configuration, IEventAggregator broker)
        {
            this.configuration = configuration;
            this.broker = broker;
        }

        public void run()
        {
            broker.subscribe(configuration);
        }
    }
}