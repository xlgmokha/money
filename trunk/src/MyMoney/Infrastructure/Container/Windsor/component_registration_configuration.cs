using Castle.Core;
using Castle.MicroKernel.Registration;
using MyMoney.Domain.Core;
using MyMoney.Infrastructure.interceptors;

namespace MyMoney.Infrastructure.Container.Windsor
{
    public interface IRegistrationConfiguration
    {
        void configure(ComponentRegistration registration);
    }

    public class component_registration_configuration : IRegistrationConfiguration
    {
        public void configure(ComponentRegistration registration)
        {
            var implementation = registration.Implementation;
            if (implementation.GetInterfaces().Length == 0) {
                registration.For(implementation);
            }
            else {
                if (implementation.GetCustomAttributes(typeof (SingletonAttribute), false).Length > 0) {
                    registration.LifeStyle.Is(LifestyleType.Singleton);
                }
                registration.LifeStyle.Is(LifestyleType.Transient);
            }

            if (typeof (IRepository).IsAssignableFrom(implementation)) {
                registration
                    .Interceptors(new InterceptorReference(typeof (ILoggingInterceptor)))
                    .First
                    .If((k, m) => true);
            }
        }
    }
}