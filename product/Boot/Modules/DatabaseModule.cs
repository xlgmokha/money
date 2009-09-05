using Gorilla.Commons.Infrastructure.Eventing;
using MoMoney.DataAccess;

namespace MoMoney.Modules
{
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