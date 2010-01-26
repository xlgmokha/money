using System;

namespace gorilla.commons.utility
{
    public class FuncSpecification<T> : Specification<T>
    {
        Func<T, bool> condition;

        public FuncSpecification(Func<T, bool> condition)
        {
            this.condition = condition;
        }

        public bool is_satisfied_by(T item)
        {
            return condition(item);
        }
    }
}