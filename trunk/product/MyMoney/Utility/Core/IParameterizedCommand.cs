namespace MyMoney.Utility.Core
{
    public interface IParameterizedCommand<T>
    {
        void run(T item);
    }
}