namespace MoMoney.Infrastructure.transactions2
{
    public interface ITrackerEntry<T>
    {
        T current { get; }
        bool has_changes();
    }
}