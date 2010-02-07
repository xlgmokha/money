using System;
using Gorilla.Commons.Infrastructure.Container;
using gorilla.commons.utility;
using MoMoney.Service.Infrastructure.Eventing;

namespace presentation.windows.commands
{
    public class ContainerAwareParameterizedCommandBuilder<T> : ParameterizedCommandBuilder<T>, Command
    {
        readonly T data;
        Action action;
        EventAggregator event_broker;

        public ContainerAwareParameterizedCommandBuilder(T data, EventAggregator event_broker)
        {
            this.data = data;
            this.event_broker = event_broker;
        }

        public Command build<TCommand>(string message) where TCommand : ArgCommand<T>
        {
            action = () =>
            {
                event_broker.publish(new UpdateOnLongRunningProcess
                                     {
                                         message = message,
                                         percent_complete = 0,
                                     });
                Resolve.the<TCommand>().run_against(data);
                event_broker.publish(new UpdateOnLongRunningProcess
                                     {
                                         percent_complete = 100,
                                     });
            };

            return this;
        }

        public void run()
        {
            action();
        }
    }
}