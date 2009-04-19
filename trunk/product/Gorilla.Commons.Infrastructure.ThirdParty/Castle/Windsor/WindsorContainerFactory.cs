using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Gorilla.Commons.Utility.Core;

namespace MoMoney.Infrastructure.Container.Windsor
{
    public interface IWindsorContainerFactory : IFactory<IWindsorContainer>
    {
    }

    public class WindsorContainerFactory : IWindsorContainerFactory
    {
        public IWindsorContainer create()
        {
            return new WindsorContainer();
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

                                             return (first != null) ? new[] {first} : null;
                                         });
        }
    }
}