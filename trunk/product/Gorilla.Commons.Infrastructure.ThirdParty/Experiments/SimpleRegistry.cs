using System;
using System.Collections.Generic;
using System.Linq;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Utility.Extensions;

namespace Gorilla.Commons.Infrastructure.Experiments
{
    public class SimpleRegistry : IDependencyRegistry
    {
        readonly IDictionary<Type, IList<IExtendedRegistration>> registrations;

        public SimpleRegistry(IDictionary<Type, IList<IExtendedRegistration>> registrations)
        {
            this.registrations = registrations;
        }

        public Interface get_a<Interface>()
        {
            return registrations[typeof (Interface)].First().downcast_to<IResolver<Interface>>().build();
        }

        public IEnumerable<Interface> all_the<Interface>()
        {
            foreach (var registration in registrations[typeof(Interface)])
            {
                yield return registration.downcast_to<IResolver<Interface>>().build()

                
            }
            yield return registrations[typeof(Interface)].each(x => x.downcast_to<IResolver<Interface>>().build());
        }
    }
}