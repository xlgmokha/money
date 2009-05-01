using Gorilla.Commons.Infrastructure.Castle.DynamicProxy;
using Gorilla.Commons.Utility.Core;

namespace Gorilla.Commons.Infrastructure.Experiments
{
    public interface IExtendedRegistration
    {
        string pretty_print { get; }
    }

    public interface IExtendedRegistration<T> : IExtendedRegistration where T : class
    {
        IExtendedRegistration<T> as_singleton();
        IExtendedRegistration<T> with_expiry(string date_time);
        IExtendedRegistration<T> with_proxy(IConfiguration<IProxyBuilder<T>> configuration);
    }
}