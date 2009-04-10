using System.Reflection;
using MoMoney.Infrastructure.Container;
using MoMoney.Infrastructure.interceptors;
using MoMoney.Infrastructure.reflection;
using MoMoney.Modules.Core;
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
                () => new ApplicationController(Lazy.load<IPresenterRegistry>(), Lazy.load<IShell>()));
            registry.transient(typeof (IRunThe<>), typeof (RunThe<>));
            registry.transient<IFileMenu, FileMenu>();
            registry.transient<IWindowMenu, WindowMenu>();
            registry.transient<IHelpMenu, HelpMenu>();

            item
                .all_types()
                .where(x => typeof (IPresenter).IsAssignableFrom(x))
                .where(x => !x.IsInterface)
                .where(x => !x.IsAbstract)
                .each(type => registry.transient(typeof (IPresenter), type));

            item
                .all_types()
                .where(x => typeof (IModule).IsAssignableFrom(x))
                .where(x => !x.IsInterface)
                .where(x => !x.IsAbstract)
                .each(type => registry.transient(typeof (IModule), type));
        }
    }
}