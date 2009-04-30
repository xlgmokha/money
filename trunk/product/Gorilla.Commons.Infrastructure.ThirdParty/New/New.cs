using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using Gorilla.Commons.Infrastructure.Castle.DynamicProxy;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Utility;
using Gorilla.Commons.Utility.Core;
using Gorilla.Commons.Utility.Extensions;

namespace Gorilla.Commons.Infrastructure.New
{
    public interface IContainerBuilder : IBuilder<IDependencyRegistry>
    {
        IExtendedRegistration<T> register<T>(Expression<Func<T>> func) where T : class;
    }

    public interface IExtendedRegistration
    {
        string pretty_print { get; }
    }

    public interface IExtendedRegistration<T> : IExtendedRegistration where T: class
    {
        IExtendedRegistration<T> as_singleton();
        IExtendedRegistration<T> with_expiry(string dateTime);
        IExtendedRegistration<T> with_proxy(IConfiguration<IProxyBuilder<T>> configuration);
    }

    public class SimpleContainerBuilder : IContainerBuilder
    {
        IDictionary<Type, IExtendedRegistration> registries = new Dictionary<Type, IExtendedRegistration>();

        public IDependencyRegistry build()
        {
            throw new NotImplementedException();
        }

        public IExtendedRegistration<T> register<T>(Expression<Func<T>> func) where T : class
        {
            try
            {
                var reg = new ExtendedRegistration<T>(func);
                registries.Add(typeof (T), reg);
                return reg;
            }
            catch (ArgumentException e)
            {
                throw new TypeAlreadyRegisteredInContainerException(typeof (T), registries[typeof (T)].pretty_print);
            }
        }
    }

    public class ExtendedRegistration<T> : IExtendedRegistration<T> where T : class
    {
        Func<T> func;
        public const string time_format = "dd/MM/yyyy HH:mm:ss";

        public ExtendedRegistration(Expression<Func<T>> expression)
        {
            pretty_print = expression.ToString();
            func = expression.Compile();
        }

        public string pretty_print { get; set; }

        public IExtendedRegistration<T> as_singleton()
        {
            func = func.memorize<T>();
            return this;
        }

        public IExtendedRegistration<T> with_expiry(string dateTime)
        {
            var theDateTime = DateTime.ParseExact(dateTime, time_format, CultureInfo.InvariantCulture);
            var original_func = func;

            func = () =>
                       {
                           if (Clock.now() > theDateTime)
                           {
                               throw new ObjectUsageHasExpiredException(original_func().GetType(), dateTime);
                           }

                           return original_func();
                       };
            return this;
        }

        public IExtendedRegistration<T> with_proxy(IConfiguration<IProxyBuilder<T>> configuration)
        {
            throw new NotImplementedException();
        }
    }

    public class TypeAlreadyRegisteredInContainerException : Exception
    {
        public TypeAlreadyRegisteredInContainerException(Type typeNotFound, string registration)
            : base(build_message(typeNotFound, registration))
        {
        }

        static string build_message(Type typeNotFound, string registration)
        {
            return string.Format("The type {0} has already been registered with {1} in the container",
                                 typeNotFound.FullName, registration);
        }
    }

    internal class ObjectUsageHasExpiredException : Exception
    {
        public ObjectUsageHasExpiredException(Type type, string dateTime) : base(build_message(type, dateTime))
        {
        }

        static string build_message(Type type, string dateTime)
        {
            return string.Format("Cannot use {0} after {1}.", type.Name, dateTime);
        }
    }
}