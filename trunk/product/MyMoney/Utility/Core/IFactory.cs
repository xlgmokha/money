namespace MyMoney.Utility.Core
{
    public interface IFactory<T>
    {
        T create();
    }
}