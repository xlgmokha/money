using Castle.MicroKernel.Registration;
using Gorilla.Commons.Utility.Core;
using Gorilla.Commons.Utility.Extensions;

namespace MoMoney.Infrastructure.Container.Windsor.configuration
{
    public interface IRegistrationConfiguration : IConfiguration<ComponentRegistration>
    {
    }

    public class ComponentRegistrationConfiguration : IRegistrationConfiguration
    {
        public void configure(ComponentRegistration registration)
        {
            new RegisterComponentContract()
                .then(new ConfigureComponentLifestyle())
                .then(new ApplyLoggingInterceptor())
                //.then(new LogComponent())
                .configure(registration);
        }
    }
}