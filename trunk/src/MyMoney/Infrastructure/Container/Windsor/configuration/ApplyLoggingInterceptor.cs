using Castle.Core;
using Castle.MicroKernel.Registration;
using MyMoney.Infrastructure.interceptors;
using MyMoney.Infrastructure.Logging;

namespace MyMoney.Infrastructure.Container.Windsor.configuration
{
    public class ApplyLoggingInterceptor : IRegistrationConfiguration
    {
        public void configure(ComponentRegistration registration)
        {
            var implementation = registration.Implementation;
            if (typeof (ILoggable).IsAssignableFrom(implementation))
            {
                registration
                    .Interceptors(new InterceptorReference(typeof (ILoggingInterceptor)))
                    .First
                    .If((k, m) => true);
            }
        }
    }
}