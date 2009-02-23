using MyMoney.Infrastructure.eventing;
using MyMoney.Infrastructure.System;
using MyMoney.Presentation.Model.messages;
using MyMoney.Utility.Core;

namespace MyMoney.Presentation.Model.Menu.File.Commands
{
    public interface IExitCommand : ICommand
    {}

    public class exit_command : IExitCommand
    {
        private readonly IApplicationEnvironment application;
        private readonly IEventAggregator broker;

        public exit_command(IApplicationEnvironment application, IEventAggregator broker)
        {
            this.application = application;
            this.broker = broker;
        }

        public void run()
        {
            broker.publish<closing_the_application>();
            application.ShutDown();
        }
    }
}