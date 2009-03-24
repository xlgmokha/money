using System;
using MoMoney.Utility.Extensions;

namespace MoMoney.Infrastructure.Container.Windsor.configuration
{
    public class ComponentExclusionSpecification : IComponentExclusionSpecification
    {
        public bool is_satisfied_by(Type type)
        {
            return new NoInterfaces()
                .or(new SubclassesForm())
                .or(new ImplementationOfDependencyRegistry())
                .or(new IsAnEntity())
                .is_satisfied_by(type);
        }
    }
}