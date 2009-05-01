using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Gorilla.Commons.Infrastructure.Container;

namespace Gorilla.Commons.Infrastructure.Experiments
{
    public class SimpleContainerBuilder : IContainerBuilder
    {
        readonly IDictionary<Type, IExtendedRegistration> registries = new Dictionary<Type, IExtendedRegistration>();

        public IDependencyRegistry build()
        {
            return new SimpleRegistry(registries);
        }

        public IExtendedRegistration<T> register<T>(Expression<Func<T>> func) where T : class
        {
            try
            {
                var registration = new ExtendedRegistration<T>(func);
                registries.Add(typeof (T), registration);
                return registration;
            }
            catch (ArgumentException e)
            {
                throw new TypeAlreadyRegisteredInContainerException(typeof (T), registries[typeof (T)].pretty_print);
            }
        }
    }
}