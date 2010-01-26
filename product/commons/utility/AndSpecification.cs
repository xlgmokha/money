namespace gorilla.commons.utility
{
    public class AndSpecification<T> : Specification<T>
    {
        readonly Specification<T> left;
        readonly Specification<T> right;

        public AndSpecification(Specification<T> left, Specification<T> right)
        {
            this.left = left;
            this.right = right;
        }

        public bool is_satisfied_by(T item)
        {
            return left.is_satisfied_by(item) && right.is_satisfied_by(item);
        }
    }
}