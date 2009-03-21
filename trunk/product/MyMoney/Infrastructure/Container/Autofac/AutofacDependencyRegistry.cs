using System.Collections.Generic;
using Autofac;

namespace MoMoney.Infrastructure.Container.Autofac
{
    internal class AutofacDependencyRegistry : IDependencyRegistry
    {
        readonly IContainer container;

        public AutofacDependencyRegistry(IContainer container)
        {
            this.container = container;
        }

        public Interface get_a<Interface>()
        {
            return container.Resolve<Interface>();
        }

        public IEnumerable<Interface> all_the<Interface>()
        {
            return container.Resolve<IEnumerable<Interface>>();
        }
    }
}