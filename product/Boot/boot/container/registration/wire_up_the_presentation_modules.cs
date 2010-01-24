using System;
using Gorilla.Commons.Infrastructure.Reflection;
using gorilla.commons.infrastructure.thirdparty;
using gorilla.commons.infrastructure.thirdparty.Castle.DynamicProxy;
using gorilla.commons.utility;
using MoMoney.boot.container.registration.proxy_configuration;
using MoMoney.Presentation;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Model.Menu.File;
using MoMoney.Presentation.Model.Menu.Help;
using MoMoney.Presentation.Model.Menu.window;
using momoney.presentation.presenters;
using MoMoney.Presentation.Views;

namespace MoMoney.boot.container.registration
{
    class wire_up_the_presentation_modules : Command, ParameterizedCommand<Assembly>
    {
        readonly DependencyRegistration registry;

        public wire_up_the_presentation_modules(DependencyRegistration registry)
        {
            this.registry = registry;
        }

        public void run()
        {
            run(new ApplicationAssembly(System.Reflection.Assembly.GetExecutingAssembly()));
        }

        public void run(Assembly item)
        {
            Func<IApplicationController> target =
                () => new ApplicationController(Lazy.load<IShell>(), Lazy.load<PresenterFactory>());
            registry.proxy<IApplicationController, SynchronizedConfiguration<IApplicationController>>(target.memorize());
            registry.transient(typeof (IRunThe<>), typeof (RunThe<>));
            registry.transient<IFileMenu, FileMenu>();
            registry.transient<IWindowMenu, WindowMenu>();
            registry.transient<IHelpMenu, HelpMenu>();

            item
                .all_types()
                .where(x => typeof (IPresenter).IsAssignableFrom(x))
                .where(x => !x.IsInterface)
                .where(x => !x.IsAbstract)
                .where(x => !x.IsGenericType)
                .each(type => registry.transient(typeof (IPresenter), type));

            item
                .all_types()
                .where(x => typeof (IModule).IsAssignableFrom(x))
                .where(x => !x.IsInterface)
                .where(x => !x.IsAbstract)
                .where(x => !x.IsGenericType)
                .each(type => registry.transient(typeof (IModule), type));
        }
    }
}