using Gorilla.Commons.Utility.Core;

namespace MoMoney.Service.Application
{
    public interface IEventLog
    {
        void process(ICommand the_event);
    }
}