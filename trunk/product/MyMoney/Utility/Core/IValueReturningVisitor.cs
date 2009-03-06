namespace MoMoney.Utility.Core
{
    public interface IValueReturningVisitor<Value, T> : IVisitor<T>
    {
        Value value { get; }
        void reset();
    }
}