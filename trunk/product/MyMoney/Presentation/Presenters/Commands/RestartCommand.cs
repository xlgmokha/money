using MyMoney.Infrastructure.eventing;
using MyMoney.Infrastructure.System;
using MyMoney.Presentation.Model.messages;
using MyMoney.Utility.Core;

namespace MyMoney.Presentation.Presenters.Commands
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
            broker.publish<closing_the_application>();
            application.restart();
        }
    }
}