using System;
using MyMoney.Utility.Core;

namespace MyMoney.Utility.Extensions
{
    public static class specification_extensions
    {
        public static bool satisfies<T>(this T item_to_interrogate, Predicate<T> criteria_to_satisfy)
        {
            return criteria_to_satisfy(item_to_interrogate);
        }

        public static bool satisfies<T>(this T itemToValidate, ISpecification<T> criteriaToSatisfy)
        {
            return itemToValidate.satisfies(criteriaToSatisfy.is_satisfied_by);
        }

        public static ISpecification<T> and<T>(this ISpecification<T> left, ISpecification<T> right)
        {
            return new and_specification<T>(left, right);
        }

        public static ISpecification<T> or<T>(this ISpecification<T> left, ISpecification<T> right)
        {
            return new or_specification<T>(left, right);
        }
    }
}