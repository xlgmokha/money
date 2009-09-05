using System;
using Gorilla.Commons.Infrastructure.Castle.Windsor.Configuration;
using Gorilla.Commons.Utility.Extensions;

namespace MoMoney.boot.container
{
    public class ComponentExclusionSpecification : IComponentExclusionSpecification
    {
        public bool is_satisfied_by(Type type)
        {
            return type.has_no_interfaces()
                .or(type.subclasses_form())
                .or(type.is_an_implementation_of_dependency_registry())
                .or(type.is_an_entity())
                .or(type.is_an_interface())
                .or(type.is_abstract())
                .is_satisfied_by(type);
        }
    }
}