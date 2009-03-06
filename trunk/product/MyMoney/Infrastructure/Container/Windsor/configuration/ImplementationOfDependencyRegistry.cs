using System;

namespace MoMoney.Infrastructure.Container.Windsor.configuration
{
    public class ImplementationOfDependencyRegistry : IComponentExclusionSpecification
    {
        public bool is_satisfied_by(Type item)
        {
            return item.IsAssignableFrom(typeof (IDependencyRegistry));
        }
    }
}