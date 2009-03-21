using System;
using System.Linq;
using System.Reflection;
using MoMoney.Infrastructure.Container.Windsor;
using MoMoney.Presentation.Core;
using MoMoney.Utility.Core;
using MoMoney.Utility.Extensions;

namespace MoMoney.boot.container.registration
{
    internal class wire_up_the_presentation_modules : ICommand
    {
        readonly IContainerBuilder registry;

        public wire_up_the_presentation_modules(IContainerBuilder registry)
        {
            this.registry = registry;
        }

        public void run()
        {
            Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x => typeof (IPresentationModule).IsAssignableFrom(x))
                .each(register);
        }

        void register(Type type)
        {
            registry.transient(type.last_interface(), type);
        }
    }
}