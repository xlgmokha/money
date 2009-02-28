namespace MyMoney.Infrastructure.transactions
{
    public interface IUnitOfWorkRegistration<T>
    {
        T current { get; }
        bool contains_changes();
    }
}