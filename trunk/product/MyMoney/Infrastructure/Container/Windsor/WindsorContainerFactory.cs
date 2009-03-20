using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using MoMoney.Infrastructure.Container.Windsor.configuration;
using MoMoney.Utility.Core;

namespace MoMoney.Infrastructure.Container.Windsor
{
    public interface IWindsorContainerFactory : IFactory<IWindsorContainer>
    {
    }

    public class WindsorContainerFactory : IWindsorContainerFactory
    {
        static IWindsorContainer container;
        static readonly object mutex = new object();
        readonly IComponentExclusionSpecification criteria_to_satisfy;
        readonly IRegistrationConfiguration configuration;

        public WindsorContainerFactory()
            : this(new ComponentExclusionSpecification(), new ComponentRegistrationConfiguration())
        {
        }

        public WindsorContainerFactory(IComponentExclusionSpecification criteria_to_satisfy,
                                       IRegistrationConfiguration configuration)
        {
            this.criteria_to_satisfy = criteria_to_satisfy;
            this.configuration = configuration;
        }

        public IWindsorContainer create()
        {
            if (null == container)
            {
                lock (mutex)
                {
                    if (null == container)
                    {
                        container = register_components_into_container();
                    }
                }
            }
            return container;
        }

        IWindsorContainer register_components_into_container()
        {
            var the_container = new WindsorContainer();
            the_container.Register(
                AllTypes
                    .Pick()
                    .FromAssembly(GetType().Assembly)
                    .WithService
                    .LastInterface()
                    //.FirstInterface()
                    .Unless(criteria_to_satisfy.is_satisfied_by)
                    .Configure(x => configuration.configure(x))
                );
            return the_container;
        }
    }

    public static class e
    {
        public static BasedOnDescriptor LastInterface(this ServiceDescriptor descriptor)
        {
            return descriptor.Select(delegate(Type type, Type baseType)
                                         {
                                             Type first = null;
                                             var interfaces = type.GetInterfaces();

                                             if (interfaces.Length > 0)
                                             {
                                                 first = interfaces[0];
                                             }

                                             return (first != null) ? new Type[] {first} : null;
                                         });
        }
    }
}