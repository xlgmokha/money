using Gorilla.Commons.Infrastructure.Container;
using gorilla.commons.utility;
using MoMoney.Service.Infrastructure.Eventing;

namespace presentation.windows.commands
{
    public class ContainerCommandBuilder : CommandBuilder
    {
        EventAggregator event_aggregator;

        public ContainerCommandBuilder(EventAggregator event_aggregator)
        {
            this.event_aggregator = event_aggregator;
        }

        public ParameterizedCommandBuilder<T> prepare<T>(T data)
        {
            return new ContainerAwareParameterizedCommandBuilder<T>(data, event_aggregator);
        }

        public Command build<T>(string message) where T : Command
        {
            return new NamedCommand<T>(message, Resolve.the<T>());
        }
    }
}