using gorilla.commons.utility;
using MoMoney.Presentation.Core;
using momoney.presentation.model.events;
using MoMoney.Service.Infrastructure.Eventing;

namespace momoney.presentation.presenters
{
    public interface IRestartCommand : Command {}

    public class RestartCommand : IRestartCommand
    {
        readonly IApplication application;
        readonly IEventAggregator broker;

        public RestartCommand(IApplication application, IEventAggregator broker)
        {
            this.application = application;
            this.broker = broker;
        }

        public void run()
        {
            broker.publish<ClosingTheApplication>();
            application.restart();
        }
    }
}