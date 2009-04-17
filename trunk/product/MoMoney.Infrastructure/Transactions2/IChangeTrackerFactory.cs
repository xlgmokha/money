using MoMoney.Domain.Core;

namespace MoMoney.Infrastructure.transactions2
{
    public interface IChangeTrackerFactory
    {
        IChangeTracker<T> create_for<T>() where T : IEntity;
    }
}