using System.Reflection;
using MoMoney.Infrastructure.Container;
using MoMoney.Infrastructure.reflection;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Model.Menu.File;
using MoMoney.Presentation.Model.Menu.Help;
using MoMoney.Presentation.Model.Menu.window;
using MoMoney.Presentation.Presenters.Commands;
using MoMoney.Presentation.Views.Shell;
using MoMoney.Utility.Core;
using MoMoney.Utility.Extensions;

namespace MoMoney.boot.container.registration
{
    internal class wire_up_the_presentation_modules : ICommand, IParameterizedCommand<IAssembly>
    {
        readonly IDependencyRegistration registry;

        public wire_up_the_presentation_modules(IDependencyRegistration registry)
        {
            this.registry = registry;
        }

        public void run()
        {
            run(new ApplicationAssembly(Assembly.GetExecutingAssembly()));
        }

        public void run(IAssembly item)
        {
            registry.proxy<IApplicationController, SynchronizedConfiguration<IApplicationController>>(
                () =>
                new ApplicationController(resolve.dependency_for<IPresenterRegistry>(), resolve.dependency_for<IShell>()));
            registry.transient(typeof (IRunThe<>), typeof (RunThe<>));
            registry.transient<IFileMenu, FileMenu>();
            registry.transient<IWindowMenu, WindowMenu>();
            registry.transient<IHelpMenu, HelpMenu>();

            item
                .all_types()
                .where(x => typeof (IPresenter).IsAssignableFrom(x))
                .where(x => !x.IsInterface)
                .each(type => registry.transient(typeof (IPresenter), type));

            item
                .all_types()
                .where(x => typeof (IPresentationModule).IsAssignableFrom(x))
                .where(x => !x.IsInterface)
                .each(type => registry.transient(typeof (IPresentationModule), type));
        }
    }
}