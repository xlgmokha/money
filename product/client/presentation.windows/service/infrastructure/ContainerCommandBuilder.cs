using Gorilla.Commons.Infrastructure.Container;
using gorilla.commons.utility;
using MoMoney.Service.Infrastructure.Eventing;
using momoney.service.infrastructure.transactions;

namespace presentation.windows.service.infrastructure
{
    public class ContainerCommandBuilder : CommandBuilder
    {
        EventAggregator event_aggregator;
        IUnitOfWorkFactory unit_of_work_factory;

        public ContainerCommandBuilder(EventAggregator event_aggregator, IUnitOfWorkFactory unit_of_work_factory)
        {
            this.event_aggregator = event_aggregator;
            this.unit_of_work_factory = unit_of_work_factory;
        }

        public CommandBuilder<T> prepare<T>(T data)
        {
            return new ContainerAwareCommandBuilder<T>(data, event_aggregator, unit_of_work_factory);
        }

        public Command build<T>(string message) where T : Command
        {
            return new NamedCommand<T>(message, Resolve.the<T>());
        }
    }
}