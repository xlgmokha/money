using System;
using Autofac.Builder;
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
using momoney.presentation.views;
using MoMoney.Presentation.Views;
using MoMoney.Service.Infrastructure.Eventing;

namespace MoMoney.boot.container.registration
{
    class WireUpThePresentationModules : IStartupCommand
    {
        readonly DependencyRegistration registry;

        public WireUpThePresentationModules(DependencyRegistration registry)
        {
            this.registry = registry;
        }

        public void run_against(Assembly item)
        {
            Func<IApplicationController> target = () => new ApplicationController(Lazy.load<Shell>(), Lazy.load<PresenterFactory>(), Lazy.load<EventAggregator>(), Lazy.load<ViewFactory>());
            registry.proxy<IApplicationController, SynchronizedConfiguration<IApplicationController>>(target.memorize());

            registry.transient(typeof (IRunThe<>), typeof (RunThe<>));
            registry.transient<IFileMenu, FileMenu>();
            registry.transient<IWindowMenu, WindowMenu>();
            registry.transient<IHelpMenu, HelpMenu>();
            registry.singleton<ISaveChangesCommand, SaveChangesPresenter>();

            item
                .all_classes_that_implement<Presenter>()
                .each(type => registry.transient(typeof (Presenter), type));

            item
                .all_classes_that_implement<IModule>()
                .each(type => registry.transient(typeof (IModule), type));
        }
    }

    static public class ProxyExtensions
    {
        static public T proxy<T>(this Configuration<ProxyBuilder<T>> configuration, Func<T> target)
        {
            var proxy_builder = new CastleDynamicProxyBuilder<T>();
            configuration.configure(proxy_builder);
            return proxy_builder.create_proxy_for(target);
        }

        static public T proxy<T, Configuration>(this Func<T> target) where Configuration : Configuration<ProxyBuilder<T>>, new()
        {
            return proxy(new Configuration(), target);
        }
    }
}