namespace MoMoney.Utility.Core
{
    public interface IFactory<T>
    {
        T create();
    }
}