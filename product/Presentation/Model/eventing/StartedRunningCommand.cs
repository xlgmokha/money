using MoMoney.Service.Infrastructure.Eventing;

namespace momoney.presentation.model.eventing
{
    public class StartedRunningCommand : IEvent
    {
        public StartedRunningCommand(object running_command)
        {
            running_action = running_command;
        }

        public object running_action { get; private set; }
    }
}