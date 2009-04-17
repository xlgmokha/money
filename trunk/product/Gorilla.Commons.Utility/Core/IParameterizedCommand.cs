namespace MoMoney.Utility.Core
{
    public interface IParameterizedCommand<T>
    {
        void run(T item);
    }
}