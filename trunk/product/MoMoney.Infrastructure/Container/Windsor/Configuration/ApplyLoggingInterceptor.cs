using Castle.Core;
using Castle.MicroKernel.Registration;
using Gorilla.Commons.Infrastructure.Logging;
using MoMoney.Infrastructure.interceptors;

namespace MoMoney.Infrastructure.Container.Windsor.configuration
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