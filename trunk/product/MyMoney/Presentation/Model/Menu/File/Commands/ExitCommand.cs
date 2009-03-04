using MyMoney.Infrastructure.eventing;
using MyMoney.Infrastructure.System;
using MyMoney.Presentation.Model.messages;
using MyMoney.Utility.Core;

namespace MyMoney.Presentation.Model.Menu.File.Commands
{
    public interface IExitCommand : ICommand, ISaveChangesCallback
    {
    }

    public class ExitCommand : IExitCommand
    {
        readonly IApplicationEnvironment application;
        readonly IEventAggregator broker;
        readonly ISaveChangesCommand command;

        public ExitCommand(IApplicationEnvironment application, IEventAggregator broker, ISaveChangesCommand command)
        {
            this.application = application;
            this.command = command;
            this.broker = broker;
        }

        public void run()
        {
            command.run(this);
        }

        public void saved()
        {
            shut_down();
        }

        public void not_saved()
        {
            shut_down();
        }

        public void cancelled()
        {
        }

        void shut_down()
        {
            broker.publish<closing_the_application>();
            application.shut_down();
        }
    }
}