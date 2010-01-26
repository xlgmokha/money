using System;
using gorilla.commons.utility;

namespace MoMoney.boot.container
{
    static public class type_extensions
    {
        static public Specification<Type> has_no_interfaces(this Type item)
        {
            return new PredicateSpecification<Type>(x => x.GetInterfaces().Length == 0);
        }

        static public Specification<Type> is_a<T>(this Type item)
        {
            return new PredicateSpecification<Type>(x => typeof (T).IsAssignableFrom(x));
        }

        static public Specification<Type> is_an_interface(this Type item)
        {
            return new PredicateSpecification<Type>(x => x.IsInterface);
        }

        static public Specification<Type> is_abstract(this Type item)
        {
            return new PredicateSpecification<Type>(x => x.IsAbstract);
        }
    }
}