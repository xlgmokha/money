using Castle.MicroKernel.Registration;

namespace MoMoney.Infrastructure.Container.Windsor.configuration
{
    public class LogComponent : IRegistrationConfiguration
    {
        public void configure(ComponentRegistration registration)
        {
            var implementation = registration.Implementation;
        }
    }
}