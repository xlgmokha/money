using Castle.MicroKernel.Registration;
using MyMoney.Infrastructure.Extensions;

namespace MyMoney.Infrastructure.Container.Windsor.configuration
{
    public class LogComponent : IRegistrationConfiguration
    {
        public void configure(ComponentRegistration registration)
        {
            var implementation = registration.Implementation;
            this.log().debug("registering: {0}", implementation);
        }
    }
}