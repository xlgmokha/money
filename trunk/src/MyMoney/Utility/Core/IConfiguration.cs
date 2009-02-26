namespace MyMoney.Utility.Core
{
    public interface IConfiguration<T>
    {
        void configure(T item);
    }
}