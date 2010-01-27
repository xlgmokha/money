using gorilla.commons.utility;
using MoMoney.Presentation.Core;
using momoney.presentation.model.eventing;
using MoMoney.Service.Infrastructure.Eventing;

namespace momoney.presentation.presenters
{
    public interface IRestartCommand : Command {}

    public class RestartCommand : IRestartCommand
    {
        readonly IApplication application;
        readonly EventAggregator broker;

        public RestartCommand(IApplication application, EventAggregator broker)
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