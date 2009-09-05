using Gorilla.Commons.Infrastructure.Eventing;
using MoMoney.DataAccess;
using MoMoney.Presentation;

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