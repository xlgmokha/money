namespace MoMoney.Utility.Core
{
    public interface IVisitable<T>
    {
        void accept(IVisitor<T> visitor);
    }
}