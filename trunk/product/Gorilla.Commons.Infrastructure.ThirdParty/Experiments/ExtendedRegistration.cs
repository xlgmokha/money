using System;
using System.Globalization;
using System.Linq.Expressions;
using Gorilla.Commons.Infrastructure.Castle.DynamicProxy;
using Gorilla.Commons.Utility;
using Gorilla.Commons.Utility.Core;
using Gorilla.Commons.Utility.Extensions;

namespace Gorilla.Commons.Infrastructure.Experiments
{
    public class ExtendedRegistration<T> : IResolver<T>, IExtendedRegistration<T> where T : class
    {
        public Func<T> build { get; private set; }
        const string time_format = "dd/MM/yyyy HH:mm:ss";

        public ExtendedRegistration(Expression<Func<T>> expression)
        {
            pretty_print = expression.ToString();
            build = expression.Compile();
        }

        public string pretty_print { get; set; }

        public IExtendedRegistration<T> as_singleton()
        {
            build = build.memorize();
            return this;
        }

        public IExtendedRegistration<T> with_expiry(string date_time)
        {
            var the_date_time = DateTime.ParseExact(date_time, time_format, CultureInfo.InvariantCulture);
            var original_func = build;

            build = () =>
                        {
                            if (Clock.now() > the_date_time)
                                throw new ObjectUsageHasExpiredException(original_func().GetType(), date_time);

                            return original_func();
                        };
            return this;
        }

        public IExtendedRegistration<T> with_proxy(IConfiguration<IProxyBuilder<T>> configuration)
        {
            var original_func = build;
            build = () =>
                        {
                            var builder = new ProxyBuilder<T>();
                            configuration.configure(builder);
                            return builder.create_proxy_for(original_func);
                        };
            return this;
        }
    }
}