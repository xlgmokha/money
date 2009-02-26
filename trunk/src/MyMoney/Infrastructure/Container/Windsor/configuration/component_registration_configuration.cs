using Castle.MicroKernel.Registration;
using MyMoney.Utility.Core;
using MyMoney.Utility.Extensions;

namespace MyMoney.Infrastructure.Container.Windsor.configuration
{
    public interface IRegistrationConfiguration : IConfiguration<ComponentRegistration>
    {
    }

    public class component_registration_configuration : IRegistrationConfiguration
    {
        public void configure(ComponentRegistration registration)
        {
            new RegisterComponentContract()
                .then(new ApplyLoggingInterceptor())
                .configure(registration);
        }
    }
}