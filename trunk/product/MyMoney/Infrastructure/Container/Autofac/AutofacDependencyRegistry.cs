using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Builder;
using MoMoney.Infrastructure.Container.Windsor;
using MoMoney.Infrastructure.proxies;
using MoMoney.Utility.Core;
using MoMoney.Utility.Extensions;

namespace MoMoney.Infrastructure.Container.Autofac
{
    internal class AutofacDependencyRegistry : IDependencyRegistry, IContainerBuilder
    {
        ContainerBuilder builder;
        Func<IContainer> container;

        public AutofacDependencyRegistry() : this(new ContainerBuilder())
        {
        }

        public AutofacDependencyRegistry(ContainerBuilder builder)
        {
            this.builder = builder;
            container = () => builder.Build();
            container = container.memorize();
        }

        public void singleton<Contract, Implementation>() where Implementation : Contract
        {
            builder.Register<Implementation>().As<Contract>().SingletonScoped();
        }

        public void singleton<Contract>(Contract instance_of_the_contract)
        {
            builder.Register(instance_of_the_contract).As<Contract>().SingletonScoped();
        }

        public void transient<Contract, Implementation>() where Implementation : Contract
        {
            transient(typeof (Contract), typeof (Implementation));
        }

        public void transient(Type contract, Type implementation)
        {
            builder.Register(implementation).As(contract).FactoryScoped();
        }

        public void proxy<T>(IConfiguration<IProxyBuilder<T>> configuration, Func<T> target)
        {
            var proxy_builder = new ProxyBuilder<T>();
            configuration.configure(proxy_builder);
            builder.Register(x => proxy_builder.create_proxy_for(target)).As<T>().FactoryScoped();
        }

        public Interface get_a<Interface>()
        {
            return container().Resolve<Interface>();
        }

        public IEnumerable<Interface> all_the<Interface>()
        {
            return container().Resolve<IEnumerable<Interface>>();
        }
    }
}