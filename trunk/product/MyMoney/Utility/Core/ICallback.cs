namespace MoMoney.Utility.Core
{
    public interface ICallback
    {
        void complete();
    }

    public interface ICallback<T>
    {
        void complete(T item);
    }
}