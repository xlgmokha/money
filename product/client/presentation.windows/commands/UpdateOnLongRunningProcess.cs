using MoMoney.Service.Infrastructure.Eventing;

namespace presentation.windows.commands
{
    public class UpdateOnLongRunningProcess : IEvent
    {
        public string message { get; set; }
        public int percent_complete { get; set; }
    }
}