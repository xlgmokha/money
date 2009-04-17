using System.Collections.Generic;
using Gorilla.Commons.Utility.Core;
using MoMoney.Infrastructure.Container;

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