using System;
using System.Linq.Expressions;
using Autofac;
using Autofac.Builder;
using Autofac.Modules;
using Autofac.Registrars;
using AutofacContrib.DynamicProxy2;
using Gorilla.Commons.Infrastructure.Castle.DynamicProxy;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Infrastructure.Experiments;
using Gorilla.Commons.Utility.Core;
using Gorilla.Commons.Utility.Extensions;

namespace Gorilla.Commons.Infrastructure.New.Autofac
{
    public class AutofacContainerBuilder : IContainerBuilder
    {
        readonly ContainerBuilder builder;
        readonly Func<IContainer> container;

        public AutofacContainerBuilder() : this(new ContainerBuilder())
        {
        }

        public AutofacContainerBuilder(ContainerBuilder builder)
        {
            this.builder = builder;
            builder.RegisterModule(new ImplicitCollectionSupportModule());
            builder.RegisterModule(new StandardInterceptionModule());
            builder.SetDefaultScope(InstanceScope.Factory);
            container = () => builder.Build();
            container = container.memorize();
        }

        public IDependencyRegistry build()
        {
            throw new NotImplementedException();
        }

        public IExtendedRegistration<T> register<T>(Expression<Func<T>> func) where T : class
        {
            return new AutofacExtendedRegistration<T>(builder, func);
        }
    }

    public class AutofacExtendedRegistration<T> :  IExtendedRegistration<T> where T : class
    {
        IConcreteRegistrar registrar;

        public AutofacExtendedRegistration(ContainerBuilder builder, Expression<Func<T>> expression)
        {
            pretty_print = expression.ToString();
            registrar = builder.Register(x => expression.Compile()).As<T>();
            registrar.FactoryScoped();
        }

        public string pretty_print { get; set; }

        public IExtendedRegistration<T> as_singleton()
        {
            registrar.SingletonScoped();
            return this;
        }

        public IExtendedRegistration<T> with_expiry(string date_time)
        {
            throw new NotImplementedException();
        }

        public IExtendedRegistration<T> with_proxy(IConfiguration<IProxyBuilder<T>> configuration)
        {
            throw new NotImplementedException();
        }
    }
}