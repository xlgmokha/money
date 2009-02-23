namespace MyMoney.Utility.Core
{
    public interface IVisitor<T>
    {
        void visit(T item_to_visit);
    }
}