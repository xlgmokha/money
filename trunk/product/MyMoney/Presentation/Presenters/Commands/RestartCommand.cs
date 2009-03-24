using MoMoney.Infrastructure.eventing;
using MoMoney.Infrastructure.System;
using MoMoney.Presentation.Model.messages;
using MoMoney.Utility.Core;

namespace MoMoney.Presentation.Presenters.Commands
{
    public interface IRestartCommand : ICommand
    {
    }

    public class RestartCommand : IRestartCommand
    {
        readonly IApplicationEnvironment application;
        readonly IEventAggregator broker;

        public RestartCommand(IApplicationEnvironment application, IEventAggregator broker)
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