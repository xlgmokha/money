using System;
using Autofac;
using Autofac.Builder;
using Autofac.Modules;
using AutofacContrib.DynamicProxy2;
using MoMoney.Infrastructure.proxies;
using MoMoney.Utility.Core;
using MoMoney.Utility.Extensions;

namespace MoMoney.Infrastructure.Container.Autofac
{
    internal class AutofacDependencyRegistryBuilder : IDependencyRegistration, IBuilder<IContainer>
    {
        readonly ContainerBuilder builder;

        public AutofacDependencyRegistryBuilder() : this(new ContainerBuilder())
        {
        }

        public AutofacDependencyRegistryBuilder(ContainerBuilder builder)
        {
            this.builder = builder;
            builder.RegisterModule(new ImplicitCollectionSupportModule());
            builder.RegisterModule(new StandardInterceptionModule());
        }

        public void singleton<Contract, Implementation>() where Implementation : Contract
        {
            builder.Register<Implementation>().As<Contract>().SingletonScoped();
        }

        public void singleton<Contract>(Func<Contract> instance_of_the_contract)
        {
            builder.Register(x => instance_of_the_contract()).As<Contract>().SingletonScoped();
        }

        public void transient<Contract, Implementation>() where Implementation : Contract
        {
            transient(typeof (Contract), typeof (Implementation));
        }

        public void transient(Type contract, Type implementation)
        {
            if (contract.is_a_generic_type())
            {
                builder.RegisterGeneric(implementation).As(contract).FactoryScoped();
            }
            else
            {
                builder.Register(implementation).As(contract).FactoryScoped();
            }
        }

        public void proxy<T>(IConfiguration<IProxyBuilder<T>> configuration, Func<T> target)
        {
            var proxy_builder = new ProxyBuilder<T>();
            configuration.configure(proxy_builder);
            builder.Register(x => proxy_builder.create_proxy_for(target)).As<T>().FactoryScoped();
        }

        public IContainer build()
        {
            return builder.Build();
        }
    }
}