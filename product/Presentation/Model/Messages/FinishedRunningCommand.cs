using MoMoney.Service.Infrastructure.Eventing;

namespace MoMoney.Presentation.Model.messages
{
    public class FinishedRunningCommand : IEvent
    {
        public FinishedRunningCommand(object running_command)
        {
            completed_action = running_command;
        }

        public object completed_action { get; private set; }
    }
}