using System.Collections.Generic;
using gorilla.commons.utility;

namespace MoMoney.Service.Application
{
    public class EventLog : IEventLog
    {
        readonly IList<Command> events = new List<Command>();

        public void process(Command the_event)
        {
            the_event.run();
            events.Add(the_event);
        }
    }
}