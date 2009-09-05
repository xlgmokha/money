using System;
using System.Windows.Forms;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Utility.Core;
using MoMoney.Domain.Core;

namespace MoMoney.boot.container
{
    static public class type_extensions
    {
        static public ISpecification<Type> has_no_interfaces(this Type item)
        {
            return new PredicateSpecification<Type>(x => x.GetInterfaces().Length == 0);
        }

        static public ISpecification<Type> subclasses_form(this Type item)
        {
            return new PredicateSpecification<Type>(x => typeof (Form).IsAssignableFrom(x));
        }

        static public ISpecification<Type> is_an_implementation_of_dependency_registry(this Type item)
        {
            return new PredicateSpecification<Type>(x => typeof (IDependencyRegistry).IsAssignableFrom(x));
        }

        static public ISpecification<Type> is_an_entity(this Type item)
        {
            return new PredicateSpecification<Type>(x => typeof (IEntity).IsAssignableFrom(x));
        }

        static public ISpecification<Type> is_an_interface(this Type item)
        {
            return new PredicateSpecification<Type>(x => x.IsInterface);
        }

        static public ISpecification<Type> is_abstract(this Type item)
        {
            return new PredicateSpecification<Type>(x => x.IsAbstract);
        }
    }
}