using System;

namespace MoMoney.Utility.Core
{
    public class PredicateSpecification<T> : ISpecification<T>
    {
        readonly Predicate<T> criteria;

        public PredicateSpecification(Predicate<T> criteria)
        {
            this.criteria = criteria;
        }

        public bool is_satisfied_by(T item)
        {
            return criteria(item);
        }
    }
}