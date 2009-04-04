using MoMoney.Utility.Core;

namespace MoMoney.Infrastructure.transactions2
{
    public interface ITrackerEntryMapper<T> : IMapper<T, ITrackerEntry<T>>
    {
    }
}