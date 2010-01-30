using System;
using System.Collections.Generic;
using System.Linq;
using gorilla.commons.utility;

namespace Gorilla.Commons.Infrastructure.Reflection
{
    public class ApplicationAssembly : Assembly
    {
        IList<Type> types;

        public ApplicationAssembly(System.Reflection.Assembly assembly)
        {
            types = assembly.GetTypes().ToList();
        }

        public IEnumerable<Type> all_types()
        {
            return types;
        }

        public IEnumerable<Type> all_types(Specification<Type> matching)
        {
            return all_types().where(x => matching.is_satisfied_by(x));
        }

        public IEnumerable<Type> all_classes_that_implement<Contract>()
        {
            return all_types()
                .where(x => typeof (Contract).IsAssignableFrom(x))
                .where(x => !x.IsInterface)
                .where(x => !x.IsAbstract)
                .where(x => !x.IsGenericType);
        }
    }
}