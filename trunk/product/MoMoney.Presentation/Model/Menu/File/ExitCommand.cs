using Gorilla.Commons.Utility.Core;
using MoMoney.Infrastructure.eventing;
using MoMoney.Infrastructure.System;
using MoMoney.Presentation.Model.messages;

namespace MoMoney.Presentation.Model.Menu.File.Commands
{
    public interface IExitCommand : ICommand, ISaveChangesCallback
    {
    }

    public class ExitCommand : IExitCommand
    {
        readonly IApplication application;
        readonly IEventAggregator broker;
        readonly ISaveChangesCommand command;

        public ExitCommand(IApplication application, IEventAggregator broker, ISaveChangesCommand command)
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
            broker.publish<ClosingTheApplication>();
            application.shut_down();
        }
    }
}