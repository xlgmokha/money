using System;
using Gorilla.Commons.Utility.Core;

namespace Gorilla.Commons.Utility.Extensions
{
    static public class SpecificationExtensions
    {
        static public bool satisfies<T>(this T item_to_interrogate, Predicate<T> criteria_to_satisfy)
        {
            return criteria_to_satisfy(item_to_interrogate);
        }

        static public bool satisfies<T>(this T item_to_validate, ISpecification<T> criteria_to_satisfy)
        {
            return item_to_validate.satisfies(criteria_to_satisfy.is_satisfied_by);
        }

        static public ISpecification<T> and<T>(this ISpecification<T> left, ISpecification<T> right)
        {
            return new AndSpecification<T>(left, right);
        }

        static public ISpecification<T> or<T>(this ISpecification<T> left, ISpecification<T> right)
        {
            return new OrSpecification<T>(left, right);
        }
    }
}