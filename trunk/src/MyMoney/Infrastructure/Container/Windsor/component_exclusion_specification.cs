using System;
using System.Windows.Forms;
using MyMoney.Utility.Core;

namespace MyMoney.Infrastructure.Container.Windsor
{
    public interface IComponentExclusionSpecification : ISpecification<Type>
    {}

    public class component_exclusion_specification : IComponentExclusionSpecification
    {
        public bool is_satisfied_by(Type type)
        {
            return type.GetInterfaces().Length == 0
                   || type.IsSubclassOf(typeof (Form))
                   || type.IsAssignableFrom(typeof (IDependencyRegistry));
        }
    }
}