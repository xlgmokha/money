using presentation.windows.common;

namespace presentation.windows.events
{
    public class UpdateOnLongRunningProcess : IEvent
    {
        public string message { get; set; }
        public int percent_complete { get; set; }
    }
}