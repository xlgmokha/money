using System;
using System.Windows.Forms;
using Gorilla.Commons.Infrastructure.Container;
using gorilla.commons.infrastructure.thirdparty.Castle.Windsor.Configuration;
using gorilla.commons.utility;
using MoMoney.Domain.Core;
using MoMoney.Presentation;
using MoMoney.Presentation.Core;

namespace MoMoney.boot.container
{
    public class ComponentExclusionSpecificationImplementation : ComponentExclusionSpecification
    {
        public bool is_satisfied_by(Type type)
        {
            return type.has_no_interfaces()
                .or(type.is_a<Form>())
                .or(type.is_a<DependencyRegistry>())
                .or(type.is_a<Entity>())
                .or(type.is_an_interface())
                .or(type.is_abstract())
                .or(type.is_a<Presenter>())
                .or(type.is_a<IModule>())
                .is_satisfied_by(type);
        }
    }
}