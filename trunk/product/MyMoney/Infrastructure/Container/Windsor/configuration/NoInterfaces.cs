using System;

namespace MoMoney.Infrastructure.Container.Windsor.configuration
{
    public class NoInterfaces : IComponentExclusionSpecification
    {
        public bool is_satisfied_by(Type item)
        {
            return item.GetInterfaces().Length == 0;
        }
    }
}