using System;
using Gorilla.Commons.Infrastructure.Container;
using gorilla.commons.utility;
using MoMoney.Service.Infrastructure.Eventing;
using momoney.service.infrastructure.transactions;

namespace presentation.windows.commands
{
    public class ContainerAwareParameterizedCommandBuilder<T> : ParameterizedCommandBuilder<T>, Command
    {
        readonly T data;
        Action action;
        EventAggregator event_broker;
        IUnitOfWorkFactory factory;

        public ContainerAwareParameterizedCommandBuilder(T data, EventAggregator event_broker, IUnitOfWorkFactory factory)
        {
            this.data = data;
            this.factory = factory;
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
                //need to resolve the command on the background thread in order to resolve the thread specific session.
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
            using (var unit_of_work = factory.create())
            {
                action();
                unit_of_work.commit();
            }
        }
    }
}