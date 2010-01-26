using gorilla.commons.utility;

namespace MoMoney.Service.Application
{
    public interface IEventLog
    {
        void process(Command the_event);
    }
}