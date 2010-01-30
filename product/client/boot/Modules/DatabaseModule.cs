using momoney.database;
using MoMoney.Presentation;
using MoMoney.Service.Infrastructure.Eventing;

namespace MoMoney.Modules
{
    public class DatabaseModule : IModule
    {
        readonly IDatabaseConfiguration configuration;
        readonly EventAggregator broker;

        public DatabaseModule(IDatabaseConfiguration configuration, EventAggregator broker)
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