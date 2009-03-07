using System;
using System.Collections.Generic;
using Castle.Core;
using Castle.Windsor;
using MoMoney.Utility.Extensions;

namespace MoMoney.Infrastructure.Container.Windsor
{
    public class WindsorDependencyRegistry : IDependencyRegistry
    {
        readonly IWindsorContainer underlying_container;

        public WindsorDependencyRegistry() : this(new WindsorContainerFactory())
        {
        }

        public WindsorDependencyRegistry(IWindsorContainerFactory factory)
        {
            underlying_container = factory.create();
        }

        public Interface get_a<Interface>()
        {
            return underlying_container.Kernel.Resolve<Interface>();
        }

        public IEnumerable<Interface> all_the<Interface>()
        {
            return underlying_container.ResolveAll<Interface>();
        }

        public void singleton<Interface, Implementation>() where Implementation : Interface
        {
            var interface_type = typeof (Interface);
            var implementation_type = typeof (Implementation);
            underlying_container.AddComponent(create_a_key_using(interface_type, implementation_type), interface_type,
                                              implementation_type);
        }

        public void register_instance_of<Interface>(Interface instanceOfTheInterface)
        {
            underlying_container.Kernel.AddComponentInstance<Interface>(instanceOfTheInterface);
        }

        public void transient<Interface, Implementation>() where Implementation : Interface
        {
            underlying_container.AddComponentLifeStyle(
                create_a_key_using(typeof (Interface), typeof (Implementation)),
                typeof (Interface), typeof (Implementation), LifestyleType.Transient);
        }

        string create_a_key_using(Type interface_type, Type implementation_type)
        {
            return "{0}-{1}".formatted_using(interface_type.FullName, implementation_type.FullName);
        }
    }
}