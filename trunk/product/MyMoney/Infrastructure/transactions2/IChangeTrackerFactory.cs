namespace MoMoney.Infrastructure.transactions2
{
    public interface IChangeTrackerFactory
    {
        IChangeTracker<T> create_for<T>();
    }
}