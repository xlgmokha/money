using System;
using MyMoney.Utility.Extensions;

namespace MyMoney.Infrastructure.Container.Windsor.configuration
{
    public class ComponentExclusionSpecification : IComponentExclusionSpecification
    {
        public bool is_satisfied_by(Type type)
        {
            return
                new NoInterfaces()
                    .or(new SubclassesForm())
                    .or(new ImplementationOfDependencyRegistry())
                    .is_satisfied_by(type);
            //return type.GetInterfaces().Length == 0 || type.IsSubclassOf(typeof (Form)) || type.IsAssignableFrom(typeof (IDependencyRegistry));
        }
    }
}