using System.Collections.Generic;
using MoMoney.Infrastructure.Container;
using MoMoney.Utility.Core;

namespace MoMoney.Infrastructure.registries
{
    public class DefaultRegistry<T> : IRegistry<T>
    {
        private readonly IDependencyRegistry registry;

        public DefaultRegistry(IDependencyRegistry registry)
        {
            this.registry = registry;
        }

        public IEnumerable<T> all()
        {
            return registry.all_the<T>();
        }
    }
}