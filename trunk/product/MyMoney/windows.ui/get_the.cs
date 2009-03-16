using MoMoney.Infrastructure.Container.Windsor;
using MoMoney.Infrastructure.Container.Windsor.configuration;
using MoMoney.Presentation.Model.interaction;
using MoMoney.Utility.Core;

namespace MoMoney.windows.ui
{
    static public class get_the
    {
        static WindsorDependencyRegistry registry_resolver;

        static public WindsorDependencyRegistry registry(ICallback<notification_message> callback)
        {
            if (null == registry_resolver)
            {
                var exclusions = new ComponentExclusionSpecification();
                var registration =
                    new ComponentRegistrationConfiguration(callback ?? new EmptyCallback<notification_message>());
                var container = new WindsorContainerFactory(exclusions, registration).create();
                registry_resolver = new WindsorDependencyRegistry(container);
                registry_resolver.singleton(container);
                return registry_resolver;
            }
            return registry_resolver;
        }
    }

    public class EmptyCallback<T> : ICallback<T>
    {
        public void complete(T item)
        {
        }
    }
}