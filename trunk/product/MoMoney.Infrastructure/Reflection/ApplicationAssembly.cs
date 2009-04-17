using System;
using System.Collections.Generic;
using System.Reflection;

namespace MoMoney.Infrastructure.reflection
{
    public class ApplicationAssembly : IAssembly
    {
        readonly Assembly assembly;

        public ApplicationAssembly(Assembly assembly)
        {
            this.assembly = assembly;
        }

        public IEnumerable<Type> all_types()
        {
            return assembly.GetTypes();
        }
    }
}