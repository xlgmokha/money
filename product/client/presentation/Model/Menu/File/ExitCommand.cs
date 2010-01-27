using gorilla.commons.utility;
using MoMoney.Presentation.Core;
using momoney.presentation.model.eventing;
using MoMoney.Presentation.Model.Menu.File;
using MoMoney.Service.Infrastructure.Eventing;

namespace momoney.presentation.model.menu.file
{
    public interface IExitCommand : Command, ISaveChangesCallback
    {
    }

    public class ExitCommand : IExitCommand
    {
        readonly IApplication application;
        readonly EventAggregator broker;
        readonly ISaveChangesCommand command;

        public ExitCommand(IApplication application, EventAggregator broker, ISaveChangesCommand command)
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