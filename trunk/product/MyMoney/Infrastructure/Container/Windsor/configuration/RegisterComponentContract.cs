using Castle.MicroKernel.Registration;

namespace MyMoney.Infrastructure.Container.Windsor.configuration
{
    public class RegisterComponentContract : IRegistrationConfiguration
    {
        public void configure(ComponentRegistration registration)
        {
            var implementation = registration.Implementation;
            if (implementation.GetInterfaces().Length == 0)
            {
                registration.For(implementation);
            }
        }
    }
}