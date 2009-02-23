namespace MyMoney.Utility.Core
{
    public interface ISpecification<T>
    {
        bool is_satisfied_by(T item);
    }
}