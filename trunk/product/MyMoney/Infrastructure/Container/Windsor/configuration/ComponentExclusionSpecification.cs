using System;
using MoMoney.Infrastructure.Extensions;
using MoMoney.Utility.Extensions;

namespace MoMoney.Infrastructure.Container.Windsor.configuration
{
    public class ComponentExclusionSpecification : IComponentExclusionSpecification
    {
        public bool is_satisfied_by(Type type)
        {
            var result = new NoInterfaces()
                .or(new SubclassesForm())
                .or(new ImplementationOfDependencyRegistry())
                //.or(new IsASetOfObservations())
                .is_satisfied_by(type);

            this.log().debug("type: {0} is excluded: {1}", type, result);
            return result;
            //return type.GetInterfaces().Length == 0 || type.IsSubclassOf(typeof (Form)) || type.IsAssignableFrom(typeof (IDependencyRegistry));
        }
    }

    //public class IsASetOfObservations : IComponentExclusionSpecification
    //{
    //    public bool is_satisfied_by(Type item)
    //    {
    //        return typeof (IObservations).IsAssignableFrom(item);
    //    }
    //}
}