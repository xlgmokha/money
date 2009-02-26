namespace MyMoney.Utility.Core
{
    public class or_specification<T> : ISpecification<T>
    {
        readonly ISpecification<T> left;
        readonly ISpecification<T> right;

        public or_specification(ISpecification<T> left, ISpecification<T> right)
        {
            this.left = left;
            this.right = right;
        }

        public bool is_satisfied_by(T item)
        {
            return left.is_satisfied_by(item) || right.is_satisfied_by(item);
        }
    }
}