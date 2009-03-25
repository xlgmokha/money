using System.Reflection;
using MoMoney.Infrastructure.Container.Windsor;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Model.Menu.File;
using MoMoney.Presentation.Model.Menu.Help;
using MoMoney.Presentation.Model.Menu.window;
using MoMoney.Presentation.Presenters.Commands;
using MoMoney.Utility.Core;
using MoMoney.Utility.Extensions;

namespace MoMoney.boot.container.registration
{
    internal class wire_up_the_presentation_modules : ICommand
    {
        readonly IDependencyRegistration registry;

        public wire_up_the_presentation_modules(IDependencyRegistration registry)
        {
            this.registry = registry;
        }

        public void run()
        {
            registry.transient(typeof (IRunThe<>), typeof (RunThe<>));
            registry.transient<IFileMenu, FileMenu>();
            registry.transient<IWindowMenu, WindowMenu>();
            registry.transient<IHelpMenu, HelpMenu>();

            Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .where(x => typeof (IPresenter).IsAssignableFrom(x))
                .where(x => !x.IsInterface)
                .each(type => registry.transient(typeof (IPresenter), type));

            Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .where(x => typeof (IPresentationModule).IsAssignableFrom(x))
                .where(x => !x.IsInterface)
                .each(type => registry.transient(typeof (IPresentationModule), type));
        }
    }
}