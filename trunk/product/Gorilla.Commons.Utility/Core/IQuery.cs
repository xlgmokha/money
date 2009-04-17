namespace MoMoney.Utility.Core
{
    public interface IQuery<T>
    {
        T fetch();
    }
}