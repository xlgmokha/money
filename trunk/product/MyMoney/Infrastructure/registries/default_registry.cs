using System.Collections.Generic;
using MyMoney.Domain.Core;
using MyMoney.Infrastructure.Container;

namespace MyMoney.Infrastructure.registries
{
    public class default_registry<T> : IRegistry<T>
    {
        private readonly IDependencyRegistry registry;

        public default_registry(IDependencyRegistry registry)
        {
            this.registry = registry;
        }

        public IEnumerable<T> all()
        {
            return registry.all_the<T>();
        }
    }
}