using Castle.MicroKernel.Registration;
using MoMoney.Presentation.Model.interaction;
using MoMoney.Utility.Core;
using MoMoney.Utility.Extensions;

namespace MoMoney.Infrastructure.Container.Windsor.configuration
{
    public interface IRegistrationConfiguration : IConfiguration<ComponentRegistration>
    {
    }

    public class ComponentRegistrationConfiguration : IRegistrationConfiguration
    {
        readonly ICallback<notification_message> callback;

        public ComponentRegistrationConfiguration(ICallback<notification_message> callback)
        {
            this.callback = callback;
        }

        public void configure(ComponentRegistration registration)
        {
            new RegisterComponentContract()
                .then(new ConfigureComponentLifestyle())
                .then(new ApplyLoggingInterceptor())
                //.then(new LogComponent())
                .configure(registration);
            callback.complete("registered:{0}".formatted_using(registration.Implementation));
        }
    }
}