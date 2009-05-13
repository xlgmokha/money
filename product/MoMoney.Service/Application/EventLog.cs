using System.Collections.Generic;
using Gorilla.Commons.Utility.Core;

namespace MoMoney.Service.Application
{
    public interface IEventLog
    {
        void process(ICommand the_event);
    }

    public class EventLog : IEventLog
    {
        readonly IList<ICommand> events = new List<ICommand>();

        public void process(ICommand the_event)
        {
            the_event.run();
            events.Add(the_event);
        }
    }
}